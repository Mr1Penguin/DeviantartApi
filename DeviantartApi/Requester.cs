﻿using Newtonsoft.Json;
using System;
#if LOG_NETWORK
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
#if LOG_NETWORK
        private static int _requestId = 0;
#endif

        private static Login.Scope[] _scope;
        public static string AccessToken { get; set; }
        public static DateTime AccessTokenExpire { get; set; }
        public static string RefreshToken { get; set; }
        public static string AppSecret { get; set; }
        public static string AppClientId { get; set; }
        public static Uri CallbackUrl { get; set; }
        public static bool AutoAccessTokenCheckingDisabled { get; set; }
        private static DateTime? LastTimeAccessTokenChecked { get; set; }
        private static int DelayStep { get; set; }
        private static Task DelayRemoverTask { get; set; }
        private static CancellationTokenSource DelayCancellationTokenSource { get; set; } = new CancellationTokenSource();


        private static HttpClient _httpClient = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });

        internal static Action<string> _refreshTokenUpdated;

        public static void SetScope(Login.Scope[] scopes)
        {
            _scope = scopes;
        }

        public static void SetTokenUpdatedHandler(Action<string> handler)
        {
            _refreshTokenUpdated = handler;
        }

        public static Task<T> MakeRequestAsync<T>(
            Uri url,
            HttpContent content = null,
            string minorVersion = "20160316", /*actual version on 2016-07-13*/
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return MakeRequestAsync<T>(url, content, HttpMethod.Get, minorVersion, cancellationToken);
        }

        public static async Task<T> MakeRequestAsync<T>(
            Uri url,
            HttpContent content,
            HttpMethod method,
            string minorVersion = "20160316", /*actual version on 2016-07-13*/
            CancellationToken cancellationToken = default(CancellationToken))
        {
#if LOG_NETWORK
            int requestId = Interlocked.Increment(ref _requestId);
            Debug.WriteLine($"{requestId}. HTTP REQUEST [{method}]: {url}");
            Debug.WriteLine($"{requestId}. HTTP BODY: " + (content != null ? await content.ReadAsStringAsync().ConfigureAwait(false) : "null"));
#endif
            cancellationToken.ThrowIfCancellationRequested();
            var httpRequestMessage = GetRequestMessage(url, minorVersion, content, method);

            var timeoutSource = new CancellationTokenSource(new TimeSpan(0, 0, 30));
            HttpResponseMessage result;
            cancellationToken.ThrowIfCancellationRequested();
            do
            {
                await Task.Delay(new TimeSpan(0, 0, DelayStep), cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                try
                {
                    using (
                        var combined = CancellationTokenSource.CreateLinkedTokenSource(
                            cancellationToken,
                            timeoutSource.Token))
                    {
                        result = await _httpClient.SendAsync(httpRequestMessage, combined.Token).ConfigureAwait(false);
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
#if LOG_NETWORK
                    Debug.WriteLine($"{requestId}. HTTP STATUS: {result.StatusCode}", "Category");
#endif
                    break;
                }

                cancellationToken.ThrowIfCancellationRequested();
                DelayStep = DelayStep == 0 ? 1 : DelayStep << 1;
#if LOG_NETWORK
                Debug.WriteLine($"{requestId}. Delay increased to: {DelayStep * 1000}");
#endif
                DelayCancellationTokenSource.Cancel();
                DelayCancellationTokenSource.Dispose();
                DelayCancellationTokenSource = new CancellationTokenSource();
                DelayRemoverTask = DelayRemover();
                if (DelayStep == 16)
                    throw new Exception("Too many requests");
                timeoutSource = new CancellationTokenSource(new TimeSpan(0, 0, 30));
                httpRequestMessage = GetRequestMessage(url, minorVersion, content, method);
            } while (true);
            cancellationToken.ThrowIfCancellationRequested();
            var reqResponse = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
#if LOG_NETWORK
            Debug.WriteLine($"{requestId}. HTTP REQUEST RESPONSE: {reqResponse}");
#endif
            var response = Deserialize<T>(reqResponse);
            return response;
        }

        public static async Task<T> MakeMultiPartPostRequestAsync<T>(
            Uri url,
            MultipartFormDataContent content,
            string minorVersion = "20160316", /*actual version on 2016-07-13*/
            CancellationToken cancellationToken = default(CancellationToken))
        {
#if LOG_NETWORK
            int requestId = Interlocked.Increment(ref _requestId);
            Debug.WriteLine($"{requestId}. HTTP REQUEST [POST]: {url}");
            Debug.WriteLine($"{requestId}. HTTP BODY: " + (content != null ? await content.ReadAsStringAsync().ConfigureAwait(false) : "null"));
#endif
            cancellationToken.ThrowIfCancellationRequested();
            var httpRequestMessage = GetRequestMessage(url, minorVersion, content, HttpMethod.Post);
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
                        result = await _httpClient.SendAsync(httpRequestMessage, combined.Token).ConfigureAwait(false);
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
#if LOG_NETWORK
                    Debug.WriteLine($"{requestId}. HTTP STATUS: {result.StatusCode}");
#endif
                    break;
                }
                cancellationToken.ThrowIfCancellationRequested();
                i = i == 0 ? 1 : i << 1;
                if (i == 8)
                    throw new Exception("Request timed out");
                await Task.Delay(i, cancellationToken).ConfigureAwait(false);
                timeoutSource = new CancellationTokenSource(new TimeSpan(0, 5, 0));
                httpRequestMessage = GetRequestMessage(url, minorVersion, content, HttpMethod.Post);
            } while (true);
            cancellationToken.ThrowIfCancellationRequested();
            var reqResponse = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
#if LOG_NETWORK
            Debug.WriteLine($"{requestId}. HTTP REQUEST RESPONSE: {reqResponse}");
#endif
            var response = Deserialize<T>(reqResponse);
            return response;
        }

        private static HttpRequestMessage GetRequestMessage(Uri url, string minorVersion,
            HttpContent content, HttpMethod method)
        {
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

            var httpRequestMessage = new HttpRequestMessage(method, url)
            {
                Content = content
            };

            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpRequestMessage.Headers.Add("dA-minor-version", minorVersion);
            httpRequestMessage.Headers.UserAgent.ParseAdd("DeviantartApi");
            return httpRequestMessage;
        }

        public static Task CheckTokenAsync()
        {
            return CheckTokenAsync(CancellationToken.None);
        }

        public static async Task CheckTokenAsync(CancellationToken cancellationToken)
        {
            if (AutoAccessTokenCheckingDisabled) return;
            var lastChecked = LastTimeAccessTokenChecked;
            if (LastTimeAccessTokenChecked?.AddMinutes(20) > DateTime.Now && AccessTokenExpire > LastTimeAccessTokenChecked?.AddMinutes(20))
                return;
            cancellationToken.ThrowIfCancellationRequested();
            LastTimeAccessTokenChecked = DateTime.Now;
            var placeboStatus = (await new Requests.Utils.PlaceboRequest().ExecuteAsync(cancellationToken).ConfigureAwait(false)).Result;
            if (placeboStatus.Status == "success" && (lastChecked == null || AccessTokenExpire > lastChecked?.AddMinutes(20))) return;
            LoginResult loginResult;
            if (RefreshToken != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                loginResult = await Login.SetAccessTokenByRefreshAsync(AppClientId, AppSecret, CallbackUrl, RefreshToken, _refreshTokenUpdated, _scope, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (loginResult.IsLoginError)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    if (loginResult.LoginErrorShortText == "invalid_request")
                    {
                        var newLoginResult = await Login.SignInAsync(AppClientId, AppSecret, CallbackUrl, _refreshTokenUpdated, _scope, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                loginResult = await Login.ClientCredentialsGrantAsync(AppClientId, AppSecret, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                if (loginResult.IsLoginError)
                    throw new Exception("Error: " + loginResult.LoginErrorText);
            }
        }

        private static T Deserialize<T>(string json) => JsonConvert.DeserializeObject<T>(json);

        public static void SetAppData(string appClientId, string appSecret)
        {
            AppClientId = appClientId;
            AppSecret = appSecret;
        }

        private static Task DelayRemover()
        {
            return Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(new TimeSpan(0, 0, 10), DelayCancellationTokenSource.Token).ConfigureAwait(false);
                    DelayCancellationTokenSource.Token.ThrowIfCancellationRequested();
                    if (DelayStep != 0)
                    {
                        DelayStep >>= 1;
#if LOG_NETWORK
                        Debug.WriteLine($"Delay Decreased to: {DelayStep * 1000}");
#endif
                    }
                }
            }, DelayCancellationTokenSource.Token);
        }
    }
}
