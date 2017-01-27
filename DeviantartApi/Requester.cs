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

        public static string AccessToken { get; set; }
        public static DateTime AccessTokenExpire { get; set; }
        public static string RefreshToken { get; set; }
        internal static string AppSecret;
        internal static string AppClientId;
        internal static Login.Scope[] Scopes;
        internal static string CallbackUrl;
        internal static bool AutoAccessTokenCheckingDisabled;
        private static DateTime? LastTimeAccessTokenChecked;

        private static HttpClient _httpClient = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });

        internal static Login.RefreshTokenUpdated Updated;

        public static async Task<T> MakeRequestAsync<T>(
            string uri,
            HttpContent content = null,
            string majorVersion = "1",
            string minorVersion = "20160316" /*actual version on 2016-07-13*/)
        {
            return await MakeRequestAsync<T>(uri, CancellationToken.None, content, majorVersion, minorVersion);
        }

        public static async Task<T> MakeRequestAsync<T>(
            string uri,
            CancellationToken cancellationToken,
            HttpContent content = null,
            string majorVersion = "1",
            string minorVersion = "20160316" /*actual version on 2016-07-13*/)
        {
            return await MakeRequestAsync<T>(uri, content, HttpMethod.Get, cancellationToken, majorVersion, minorVersion);
        }

        public static async Task<T> MakeRequestAsync<T>(
            string uri,
            HttpContent content,
            HttpMethod method,
            string majorVersion = "1",
            string minorVersion = "20160316" /*actual version on 2016-07-13*/)
        {
            return await MakeRequestAsync<T>(uri, content, method, CancellationToken.None, majorVersion, minorVersion);
        }

        public static async Task<T> MakeRequestAsync<T>(
            string uri,
            HttpContent content,
            HttpMethod method,
            CancellationToken cancellationToken,
            string majorVersion = "1",
            string minorVersion = "20160316" /*actual version on 2016-07-13*/)
        {
#if DEBUG
            int requestId = Interlocked.Increment(ref _requestId);
            Debug.WriteLine($"{requestId}. HTTP REQUEST [{method}]: " + (uri.StartsWith("http") ? uri : $"https://www.deviantart.com/api/v{majorVersion}/oauth2/" + uri));
            Debug.WriteLine($"{requestId}. HTTP BODY: " + (content != null ? await content.ReadAsStringAsync() : "null"));
#endif
            cancellationToken.ThrowIfCancellationRequested();
            var httpRequestMessage = GetRequestMessage(uri, majorVersion, minorVersion, content, method);

            var timeoutSource = new CancellationTokenSource(new TimeSpan(0, 0, 30));
            HttpResponseMessage result;
            var i = 0;
            cancellationToken.ThrowIfCancellationRequested();
            do
            {
                try
                {
                    using (
                        var combined = CancellationTokenSource.CreateLinkedTokenSource(
                            cancellationToken,
                            timeoutSource.Token))
                    {
                        result = await _httpClient.SendAsync(httpRequestMessage, combined.Token);
                    }
                }
                catch (OperationCanceledException)
                {
                    if (timeoutSource.Token.IsCancellationRequested)
                    {
                        throw new Exception("Request timed out");
                    }

                    throw;
                }

                if (result.StatusCode != (HttpStatusCode)429)
                {
#if DEBUG
                    Debug.WriteLine($"{requestId}. HTTP STATUS: {result.StatusCode}", "Category");
#endif
                    break;
                }

                cancellationToken.ThrowIfCancellationRequested();
                i = i == 0 ? 1 : i << 1;
                if (i == 32)
                    throw new Exception("Too many requests");
                await Task.Delay(i * 1000, cancellationToken);
                timeoutSource = new CancellationTokenSource(new TimeSpan(0, 0, 30));
                httpRequestMessage = GetRequestMessage(uri, majorVersion, minorVersion, content, method);
            } while (true);
            cancellationToken.ThrowIfCancellationRequested();
            var reqResponse = await result.Content.ReadAsStringAsync();
#if DEBUG
            Debug.WriteLine($"{requestId}. HTTP REQUEST RESPONSE: {reqResponse}");
#endif
            var response = Deserialize<T>(reqResponse);
            return response;
        }

        public static async Task<T> MakeMultiPartPostRequestAsync<T>(
            string uri,
            MultipartFormDataContent content,
            string majorVersion = "1",
            string minorVersion = "20160316" /*actual version on 2016-07-13*/)
        {
            return
                await MakeMultiPartPostRequestAsync<T>(uri, content, CancellationToken.None, majorVersion, minorVersion);
        }

        public static async Task<T> MakeMultiPartPostRequestAsync<T>(
            string uri,
            MultipartFormDataContent content,
            CancellationToken cancellationToken,
            string majorVersion = "1",
            string minorVersion = "20160316" /*actual version on 2016-07-13*/)
        {
#if DEBUG
            int requestId = Interlocked.Increment(ref _requestId);
            Debug.WriteLine($"{requestId}. HTTP REQUEST [POST]: " + (uri.StartsWith("http") ? uri : $"https://www.deviantart.com/api/v{majorVersion}/oauth2/" + uri));
            Debug.WriteLine($"{requestId}. HTTP BODY: " + (content != null ? await content.ReadAsStringAsync() : "null"));
#endif
            cancellationToken.ThrowIfCancellationRequested();
            var httpRequestMessage = GetRequestMessage(uri, majorVersion, minorVersion, content, HttpMethod.Post);
            httpRequestMessage.Content.Headers.ContentType.MediaType = "multipart/form-data; boundary=deviapi---" + DateTime.Now.Ticks.ToString("x");
            var timeoutSource = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            HttpResponseMessage result;
            var i = 0;
            cancellationToken.ThrowIfCancellationRequested();
            do
            {
                try
                {
                    using (
                        var combined = CancellationTokenSource.CreateLinkedTokenSource(
                            cancellationToken,
                            timeoutSource.Token))
                    {
                        result = await _httpClient.SendAsync(httpRequestMessage, combined.Token);
                    }
                }
                catch (OperationCanceledException)
                {
                    if (timeoutSource.Token.IsCancellationRequested)
                    {
                        throw new Exception("Request timed out");
                    }

                    throw;
                }
                if (result.StatusCode != (HttpStatusCode)429)
                {
#if DEBUG
                    Debug.WriteLine($"{requestId}. HTTP STATUS: {result.StatusCode}");
#endif
                    break;
                }
                cancellationToken.ThrowIfCancellationRequested();
                i = i == 0 ? 1 : i << 1;
                if (i == 8)
                    throw new Exception("Request timed out");
                await Task.Delay(i, cancellationToken);
                timeoutSource = new CancellationTokenSource(new TimeSpan(0, 5, 0));
                httpRequestMessage = GetRequestMessage(uri, majorVersion, minorVersion, content, HttpMethod.Post);
            } while (true);
            cancellationToken.ThrowIfCancellationRequested();
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
            await CheckTokenAsync(CancellationToken.None);
        }

        public static async Task CheckTokenAsync(CancellationToken cancellationToken)
        {
            if (AutoAccessTokenCheckingDisabled) return;
            if (LastTimeAccessTokenChecked != null && LastTimeAccessTokenChecked.Value.AddMinutes(20) > DateTime.Now)
                return;
            cancellationToken.ThrowIfCancellationRequested();
            LastTimeAccessTokenChecked = DateTime.Now;
            var placeboStatus = (await new Requests.PlaceboRequest().ExecuteAsync(cancellationToken)).Object;
            if (placeboStatus.Status == "success" && AccessTokenExpire > DateTime.Now) return;
            Login.LoginResult loginResult;
            if (RefreshToken != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                loginResult = await Login.SetAccessTokenByRefreshAsync(AppClientId, AppSecret, CallbackUrl, RefreshToken, Updated, cancellationToken, Scopes);
                if (loginResult.IsLoginError)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    if (loginResult.LoginErrorShortText == "invalid_request")
                    {
                        var newLoginResult = await Login.SignInAsync(AppClientId, AppSecret, CallbackUrl, Updated, cancellationToken, Scopes);
                        cancellationToken.ThrowIfCancellationRequested();
                        if (newLoginResult.IsLoginError)
                            throw new Exception(newLoginResult.LoginErrorText);
                    }
                    throw new Exception("Unexpected error: " + loginResult.LoginErrorText);
                }
            }
            else
            {
                cancellationToken.ThrowIfCancellationRequested();
                loginResult = await Login.ClientCredentialsGrantAsync(AppClientId, AppSecret, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
                if (loginResult.IsLoginError)
                    throw new Exception("Error: " + loginResult.LoginErrorText);
            }
        }

        private static T Deserialize<T>(string json) => JsonConvert.DeserializeObject<T>(json);
    }
}
