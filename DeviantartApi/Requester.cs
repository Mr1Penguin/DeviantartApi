using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DeviantartApi
{
    internal class Requester
    {

        internal static string AccessToken;
        internal static DateTime AccessTokenExpire;
        internal static string RefreshToken;
        internal static string AppSecret;
        internal static string AppClientId;
        internal static Login.Scope[] Scopes;
        internal static string CallbackUrl;

        internal static Login.RefreshTokenUpdated Updated;

        public static async Task<T> MakeRequestAsync<T>(string uri, HttpContent content = null)
        {
            return await MakeRequestAsync<T>(uri, content, HttpMethod.Get);
        }

        public static async Task<T> MakeRequestAsync<T>(string uri, HttpContent content, HttpMethod method)
        {
            var timeOut = new TimeSpan(0, 0, 30);

            var httpRequestMessage = new HttpRequestMessage(method, new Uri(uri))
            {
                Content = content
            };
            httpRequestMessage.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
            httpRequestMessage.Headers.Add("Pragma", "no-cache");
            httpRequestMessage.Headers.UserAgent.ParseAdd("DeviantartApi");

            var timeoutSource = new CancellationTokenSource(timeOut);
            HttpResponseMessage result;
            var i = 0;
            do
            {
                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        result = await httpClient.SendAsync(httpRequestMessage,timeoutSource.Token);
                    }
                    catch (TaskCanceledException)
                    {
                        throw new Exception("Request timed out");
                    }
                }
                if (result.StatusCode != (HttpStatusCode) 429) break;
                i = i == 0 ? 1 : i << 1;
                if (i == 8) throw new Exception("Request timed out");
                await Task.Delay(i);
                timeoutSource = new CancellationTokenSource(timeOut);
                httpRequestMessage = new HttpRequestMessage(method, new Uri(uri))
                {
                    Content = content
                };
                httpRequestMessage.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
                httpRequestMessage.Headers.Add("Pragma", "no-cache");
                httpRequestMessage.Headers.UserAgent.ParseAdd("DeviantartApi");
            } while (true);

            var response = Deserialize<T>(await result.Content.ReadAsStringAsync());
            return response;
        }

        internal static async Task CheckTokenAsync()
        {
            var placeboStatus = (await new Requests.PlaceboRequest().ExecuteAsync()).Object;
            if (placeboStatus.Status == "success" && AccessTokenExpire > DateTime.Now) return;
            var loginResult = await Login.SetAccessTokenByRefreshAsync(AppClientId, AppSecret, CallbackUrl, RefreshToken, Updated, Scopes);
            if (loginResult.IsLoginError)
            {
                if (loginResult.LoginErrorShortText == "invalid_request")
                {
                    var newLoginResult = await Login.SignInAsync(AppClientId, AppSecret, CallbackUrl, Updated, Scopes);
                    if (newLoginResult.IsLoginError)
                        throw new Exception(newLoginResult.LoginErrorText);
                }
                throw new Exception("Unexpected error: " + loginResult.LoginErrorText);
            }
        }

        private static T Deserialize<T>(string json) => JsonConvert.DeserializeObject<T>(json);

        private static string Serialize<T>(T t) => JsonConvert.SerializeObject(t);
    }
}
