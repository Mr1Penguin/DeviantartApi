using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DeviantartApi
{
    public static class Requester
    {

        public static string AccessToken { get; internal set; }
        internal static DateTime AccessTokenExpire;
        internal static string RefreshToken;
        internal static string AppSecret;
        internal static string AppClientId;
        internal static Login.Scope[] Scopes;
        internal static string CallbackUrl;

        private static HttpClient _httpClient = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });

        internal static Login.RefreshTokenUpdated Updated;

        public static async Task<T> MakeRequestAsync<T>(string uri, HttpContent content = null,
            string majorVersion = "1", string minorVersion = "20160316" /*actual version on 2016-07-13*/)
        {
            return await MakeRequestAsync<T>(uri, content, HttpMethod.Get, majorVersion, minorVersion);
        }

        public static async Task<T> MakeRequestAsync<T>(string uri, HttpContent content, HttpMethod method,
            string majorVersion = "1", string minorVersion = "20160316" /*actual version on 2016-07-13*/)
        {
            var timeOut = new TimeSpan(0, 0, 30);

            var httpRequestMessage = await GetRequestMessageAsync(uri, majorVersion, minorVersion, content, method);

            var timeoutSource = new CancellationTokenSource(timeOut);
            HttpResponseMessage result;
            var i = 0;
            do
            {
                try
                {
                    result = await _httpClient.SendAsync(httpRequestMessage, timeoutSource.Token);
                }
                catch (TaskCanceledException)
                {
                    throw new Exception("Request timed out");
                }
                if (result.StatusCode != (HttpStatusCode)429) break;
                i = i == 0 ? 1 : i << 1;
                if (i == 8)
                    throw new Exception("Request timed out");
                await Task.Delay(i);
                timeoutSource = new CancellationTokenSource(timeOut);
                httpRequestMessage = await GetRequestMessageAsync(uri, majorVersion, minorVersion, content, method);
            } while (true);

            var response = Deserialize<T>(await result.Content.ReadAsStringAsync());
            return response;
        }

        private static async Task<HttpRequestMessage> GetRequestMessageAsync(string uri, string majorVersion, string minorVersion,
            HttpContent content, HttpMethod method)
        {
            var httpRequestMessage = new HttpRequestMessage(method,
                new Uri(new Uri($"https://www.deviantart.com/api/v{majorVersion}/oauth2/"), uri));

            if (content == null)
                content = new ByteArrayContent(new byte[0]);

            using (var ms = new MemoryStream())
            {
                using (var contentStream = new MemoryStream())
                {
                    await content.CopyToAsync(contentStream);
                    using (var gzip = new GZipStream(ms, CompressionMode.Compress, true))
                    {
                        await contentStream.CopyToAsync(gzip);
                    }
                }
                ms.Position = 0;
                byte[] compressed = new byte[ms.Length];
                ms.Read(compressed, 0, compressed.Length);

                var outStream = new MemoryStream(compressed);

                var streamContent = new StreamContent(outStream);
                streamContent.Headers.Add("Content-Encoding", "gzip");
                streamContent.Headers.ContentLength = outStream.Length;
                httpRequestMessage.Content = streamContent;
            }

    
            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpRequestMessage.Headers.Add("dA-minor-version", minorVersion);
            httpRequestMessage.Headers.UserAgent.ParseAdd("DeviantartApi");
            return httpRequestMessage;
        }

        public static async Task CheckTokenAsync()
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
