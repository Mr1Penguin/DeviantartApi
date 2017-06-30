using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi
{
    public static class Login
    {
        public enum Scope
        {
            Basic,
            User,
            UserManage,
            Feed,
            Browse,
            BrowseMlt,
            Collection,
            CommentPost,
            Message,
            Note,
            Stash,
            Publish
        }

        public static async Task<LoginResult> SetAccessTokenByRefreshAsync(
            string clientId,
            string secret,
            Uri callbackUrl,
            string refreshToken,
            Action<string> refreshTokenUpdatedHandler,
            Scope[] scopes = null, 
            bool disableAutoAccessTokenChecking = false,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            TokenHandler tokenHandler = null;
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                var uri = new Uri("https://www.deviantart.com/oauth2/token?grant_type=refresh_token&" +
                    $"client_id={clientId}&" + $"client_secret={secret}&" + $"refresh_token={refreshToken}");
                tokenHandler = await Requester.MakeRequestAsync<TokenHandler>(uri, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                return new LoginResult
                {
                    RefreshToken = null,
                    IsLoginError = true,
                    LoginErrorText = e.Message
                };
            }
            if (tokenHandler.Error != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                return new LoginResult
                {
                    RefreshToken = null,
                    IsLoginError = true,
                    LoginErrorText = tokenHandler.ErrorDescription,
                    LoginErrorShortText = tokenHandler.Error
                };
            }
            cancellationToken.ThrowIfCancellationRequested();
            Requester.AccessToken = tokenHandler.AccessToken;
            Requester.AccessTokenExpire = DateTime.Now.AddSeconds(tokenHandler.ExpiresIn - 100);
            Requester._refreshTokenUpdated = refreshTokenUpdatedHandler;
            Requester._refreshTokenUpdated?.Invoke(tokenHandler.RefreshToken);
            Requester.RefreshToken = tokenHandler.RefreshToken;
            Requester.AppClientId = clientId;
            Requester.AppSecret = secret;
            Requester.SetScope(scopes);
            Requester.CallbackUrl = callbackUrl;
            Requester.AutoAccessTokenCheckingDisabled = disableAutoAccessTokenChecking;
            cancellationToken.ThrowIfCancellationRequested();
            return new LoginResult
            {
                RefreshToken = tokenHandler.RefreshToken,
                IsLoginError = false,
                LoginErrorText = null
            };
        }

        /// <summary>
        /// clientId, secret, callbackUrl, updated, cancellationToken, scopes -> result
        /// </summary>
        public static Func<string, string, Uri, Action<string>, CancellationToken, Scope[], Task<SignInResult>> CustomSignInAsync { get; set; }

        public static async Task<LoginResult> SignInAsync(
            string clientId,
            string secret,
            Uri callbackUrl,
            Action<string> refreshTokenUpdatedHandler,
            Scope[] scopes = null,
            bool disableAutoAccessTokenChecking = false,    
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (CustomSignInAsync == null)
            {
                throw new NullReferenceException("CustomSignInAsync is not set");
            }

            var signInResult = await CustomSignInAsync(clientId, secret, callbackUrl, refreshTokenUpdatedHandler, cancellationToken,
                scopes).ConfigureAwait(false);
            if (signInResult.IsSignInError)
                return new LoginResult
                {
                    IsLoginError = true,
                    LoginErrorShortText = signInResult.SignInErrorShortText,
                    LoginErrorText = signInResult.SignInErrorText
                };
            var code = signInResult.Code;
            cancellationToken.ThrowIfCancellationRequested();
            var tokenHandler = await GetTokenAsync(code, clientId, secret, callbackUrl, cancellationToken).ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested();
            Requester.AccessToken = tokenHandler.AccessToken;
            Requester.AccessTokenExpire = DateTime.Now.AddSeconds(tokenHandler.ExpiresIn - 100);
            if (Requester._refreshTokenUpdated != refreshTokenUpdatedHandler)
                Requester._refreshTokenUpdated = refreshTokenUpdatedHandler;
            else
                Requester._refreshTokenUpdated?.Invoke(tokenHandler.RefreshToken);
            Requester.RefreshToken = tokenHandler.RefreshToken;
            Requester.AppClientId = clientId;
            Requester.AppSecret = secret;
            Requester.SetScope(scopes);
            Requester.CallbackUrl = callbackUrl;
            Requester.AutoAccessTokenCheckingDisabled = disableAutoAccessTokenChecking;
            cancellationToken.ThrowIfCancellationRequested();
            return new LoginResult
            {
                RefreshToken = tokenHandler.RefreshToken,
                IsLoginError = false,
                LoginErrorText = null
            };
        }

        private static Task<TokenHandler> GetTokenAsync(
            string code, 
            string clientId, 
            string secret, 
            Uri callbackUrl)
        {
            return GetTokenAsync(code, clientId, secret, callbackUrl, CancellationToken.None);
        }

        private static Task<TokenHandler> GetTokenAsync(
            string code, 
            string clientId, 
            string secret, 
            Uri callbackUrl, 
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var uri = new Uri("https://www.deviantart.com/oauth2/token?" +
                              "grant_type=authorization_code&" +
                              $"client_id={clientId}&" +
                              $"client_secret={secret}&" +
                              $"code={code}&" +
                              $"redirect_uri={callbackUrl}");
            return Requester.MakeRequestAsync<TokenHandler>(uri, cancellationToken: cancellationToken);
        }

        public static Task<LoginResult> ClientCredentialsGrantAsync(
            string clientId,
            string secret,
            bool disableAutoAccessTokenChecking = false)
        {
            return ClientCredentialsGrantAsync(clientId, secret, CancellationToken.None, disableAutoAccessTokenChecking);
        }

        public static async Task<LoginResult> ClientCredentialsGrantAsync(
            string clientId,
            string secret,
            CancellationToken cancellationToken,
            bool disableAutoAccessTokenChecking = false)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var uri = new Uri("https://www.deviantart.com/oauth2/token?" + "grant_type=client_credentials&"
                        + $"client_id={clientId}&" + $"client_secret={secret}");
            var tokenHandler = await Requester.MakeRequestAsync<TokenHandler>(uri, cancellationToken: cancellationToken).ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested();
            if (tokenHandler.Error != null)
            {
                return new LoginResult
                {
                    IsLoginError = true,
                    LoginErrorText = tokenHandler.ErrorDescription,
                    LoginErrorShortText = tokenHandler.Error
                };
            }
            Requester.AccessToken = tokenHandler.AccessToken;
            Requester.AccessTokenExpire = DateTime.Now.AddSeconds(tokenHandler.ExpiresIn - 100);
            Requester._refreshTokenUpdated = null;
            Requester.RefreshToken = tokenHandler.RefreshToken;
            Requester.AppClientId = clientId;
            Requester.AppSecret = secret;
            Requester.SetScope(null);
            Requester.CallbackUrl = null;
            Requester.AutoAccessTokenCheckingDisabled = disableAutoAccessTokenChecking;
            cancellationToken.ThrowIfCancellationRequested();
            return new LoginResult { IsLoginError = false };
        }

        public static Task<bool> LogoutAsync(string token)
        {
            return LogoutAsync(token, CancellationToken.None);
        }

        public static async Task<bool> LogoutAsync(string token, CancellationToken cancellationToken)
        {
            //not tested yet
            cancellationToken.ThrowIfCancellationRequested();
            var uri = new Uri("https://www.deviantart.com/oauth2/revoke");
            return (await
                    Requester.MakeRequestAsync<LogoutStatus>(uri,
                        new FormUrlEncodedContent(new[]
                        {
                            new KeyValuePair<string, string>("token", token),
                            new KeyValuePair<string, string>("revoke_refresh_only", "true")
                        }),
                        method: HttpMethod.Post,
                        cancellationToken: cancellationToken).ConfigureAwait(false)).Success;
        }

        private class LogoutStatus
        {
            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("error")]
            public string Error { get; set; }

            [JsonProperty("error_description")]
            public string ErrorDescription { get; set; }
        }

        private class TokenHandler
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }

            [JsonProperty("token_type")]
            public string TokenType { get; set; }

            [JsonProperty("expires_in")]
            public int ExpiresIn { get; set; }

            [JsonProperty("refresh_token")]
            public string RefreshToken { get; set; }

            [JsonProperty("scope")]
            public string Scope { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("error")]
            public string Error { get; set; }

            [JsonProperty("error_description")]
            public string ErrorDescription { get; set; }
        }
    }
}
