using Newtonsoft.Json;
using System;
#if DEBUG
using System.Diagnostics;
#endif
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi
{
    public static class Requester
    {
#if DEBUG
        private static int _requestId = 0;
#endif

        public static string AccessToken { get; internal set; }
        internal static DateTime AccessTokenExpire;
        internal static string RefreshToken;
        internal static string AppSecret;
        internal static string AppClientId;
        internal static Login.Scope[] Scopes;
        internal static string CallbackUrl;
        internal static bool AutoAccessTokenCheckingDisabled;
        private static DateTime? LastTimeAccessTokenChecked;

        private static HttpClient _httpClient = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
        //private static HttpClient _chunkedHttpClient = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate , });

        internal static Login.RefreshTokenUpdated Updated;

        public static async Task<T> MakeRequestAsync<T>(string uri, HttpContent content = null,
            string majorVersion = "1", string minorVersion = "20160316" /*actual version on 2016-07-13*/)
        {
            return await MakeRequestAsync<T>(uri, content, HttpMethod.Get, majorVersion, minorVersion);
        }

        public static async Task<T> MakeRequestAsync<T>(string uri, HttpContent content, HttpMethod method,
            string majorVersion = "1", string minorVersion = "20160316" /*actual version on 2016-07-13*/)
        {
#if DEBUG
            int requestId = Interlocked.Increment(ref _requestId);
            Debug.WriteLine($"{requestId}. HTTP REQUEST [{method}]: {uri}");
            Debug.WriteLine($"{requestId}. HTTP BODY: " + (content != null ? await content.ReadAsStringAsync() : "null"));
#endif
            var timeOut = new TimeSpan(0, 0, 30);

            var httpRequestMessage = GetRequestMessage(uri, majorVersion, minorVersion, content, method);

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
                if (result.StatusCode != (HttpStatusCode)429)
                {
#if DEBUG
                    Debug.WriteLine($"{requestId}. HTTP STATUS: {result.StatusCode}");
#endif
                    break;
                }
                i = i == 0 ? 1 : i << 1;
                if (i == 32)
                    throw new Exception("Too many requests");
                await Task.Delay(i * 1000);
                timeoutSource = new CancellationTokenSource(timeOut);
                httpRequestMessage = GetRequestMessage(uri, majorVersion, minorVersion, content, method);
            } while (true);
            var reqResponse = await result.Content.ReadAsStringAsync();
#if DEBUG
            Debug.WriteLine($"{requestId}. HTTP REQUEST RESPONSE: {reqResponse}");
#endif
            var response = Deserialize<T>(reqResponse);
            return response;
        }

        public static async Task<T> MakeMultiPartPostRequestAsync<T>(string uri, MultipartFormDataContent content,
            string majorVersion = "1", string minorVersion = "20160316" /*actual version on 2016-07-13*/)
        {
#if DEBUG
            int requestId = Interlocked.Increment(ref _requestId);
            Debug.WriteLine($"{requestId}. HTTP REQUEST [POST]: {uri}");
            Debug.WriteLine($"{requestId}. HTTP BODY: " + (content != null ? await content.ReadAsStringAsync() : "null"));
#endif
            var timeOut = new TimeSpan(0, 5, 0);

            var httpRequestMessage = GetRequestMessage(uri, majorVersion, minorVersion, content, HttpMethod.Post);
            httpRequestMessage.Content.Headers.ContentType.MediaType = "multipart/form-data; boundary=deviapi---" + DateTime.Now.Ticks.ToString("x");
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
                if (result.StatusCode != (HttpStatusCode)429)
                {
#if DEBUG
                    Debug.WriteLine($"{requestId}. HTTP STATUS: {result.StatusCode}");
#endif
                    break;
                }
                i = i == 0 ? 1 : i << 1;
                if (i == 8)
                    throw new Exception("Request timed out");
                await Task.Delay(i);
                timeoutSource = new CancellationTokenSource(timeOut);
                httpRequestMessage = GetRequestMessage(uri, majorVersion, minorVersion, content, HttpMethod.Post);
            } while (true);
            var reqResponse = await result.Content.ReadAsStringAsync();
#if DEBUG
            Debug.WriteLine($"{requestId}. HTTP REQUEST RESPONSE: {reqResponse}");
#endif
            var response = Deserialize<T>(reqResponse);
            return response;
        }

        private static HttpRequestMessage GetRequestMessage(string uri, string majorVersion, string minorVersion,
            HttpContent content, HttpMethod method)
        {
            var httpRequestMessage = new HttpRequestMessage(method,
                new Uri(new Uri($"https://www.deviantart.com/api/v{majorVersion}/oauth2/"), uri));

            //Looks like deviantart can't work with incoming gzip
            /*if (content != null)
            {
                byte[] data = await content.ReadAsByteArrayAsync();
                MemoryStream ms = new MemoryStream();
                using (GZipStream gzip = new GZipStream(ms, CompressionMode.Compress, true))
                {
                    gzip.Write(data, 0, data.Length);
                }
                ms.Position = 0;
                StreamContent streamContent = new StreamContent(ms);
                streamContent.Headers.ContentEncoding.Add("gzip");
                httpRequestMessage.Content = streamContent;
            }*/
            httpRequestMessage.Content = content;

            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpRequestMessage.Headers.Add("dA-minor-version", minorVersion);
            httpRequestMessage.Headers.UserAgent.ParseAdd("DeviantartApi");
            return httpRequestMessage;
        }

        public static async Task CheckTokenAsync()
        {
            if (AutoAccessTokenCheckingDisabled) return;
            if (LastTimeAccessTokenChecked != null && LastTimeAccessTokenChecked.Value.AddMinutes(20) > DateTime.Now)
                return;
            LastTimeAccessTokenChecked = DateTime.Now;
            var placeboStatus = (await new Requests.PlaceboRequest().ExecuteAsync()).Object;
            if (placeboStatus.Status == "success" && AccessTokenExpire > DateTime.Now) return;
            Login.LoginResult loginResult;
            if (RefreshToken != null)
            {
                loginResult = await Login.SetAccessTokenByRefreshAsync(AppClientId, AppSecret, CallbackUrl, RefreshToken, Updated, Scopes);
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
            else
            {
                loginResult = await Login.ClientCredentialsGrantAsync(AppClientId, AppSecret);
                if (loginResult.IsLoginError)
                    throw new Exception("Error: " + loginResult.LoginErrorText);
            }
        }

        private static T Deserialize<T>(string json) => JsonConvert.DeserializeObject<T>(json);
    }
}
