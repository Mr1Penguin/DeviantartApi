using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DeviantartApi
{
    using System.Threading;

    public static partial class Login
    {
        public delegate void RefreshTokenUpdated(string newRefreshToken);

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

        public struct LoginResult
        {
            public string RefreshToken { get; set; }

            public bool IsLoginError { get; set; }

            public string LoginErrorText { get; set; }

            public string LoginErrorShortText { get; set; }
        }

        /*public static async Task<LoginResult> SignInAsync(string clientId, string secret, string callbackUrl,
            RefreshTokenUpdated updated, Scope[] scopes = null);*/

        public static async Task<LoginResult> ClientCredentialsGrantAsync(
            string clientId,
            string secret,
            bool disableAutoAccessTokenChecking = false)
        {
            return
                await
                    ClientCredentialsGrantAsync(
                        clientId,
                        secret,
                        CancellationToken.None,
                        disableAutoAccessTokenChecking);
        }

        public static async Task<LoginResult> ClientCredentialsGrantAsync(
            string clientId,
            string secret,
            CancellationToken cancellationToken,
            bool disableAutoAccessTokenChecking = false)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var tokenHandler =
                await
                    Requester.MakeRequestAsync<TokenHandler>(
                        "https://www.deviantart.com/oauth2/token?" + "grant_type=client_credentials&"
                        + $"client_id={clientId}&" + $"client_secret={secret}", cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            if (tokenHandler.Error != null) return new LoginResult { IsLoginError = true, LoginErrorText = tokenHandler.ErrorDescription, LoginErrorShortText = tokenHandler.Error };
            Requester.SetAccessToken(tokenHandler.AccessToken);
            Requester.AccessTokenExpire = DateTime.Now.AddSeconds(tokenHandler.ExpiresIn - 100);
            Requester.Updated = null;
            Requester.RefreshToken = tokenHandler.RefreshToken;
            Requester.AppClientId = clientId;
            Requester.AppSecret = secret;
            Requester.Scopes = null;
            Requester.CallbackUrl = null;
            Requester.AutoAccessTokenCheckingDisabled = disableAutoAccessTokenChecking;
            cancellationToken.ThrowIfCancellationRequested();
            return new LoginResult { IsLoginError = false };
        }

        private static async Task<TokenHandler> GetTokenAsync(string code, string clientId, string secret, string callbackUrl)
        {
            return await GetTokenAsync(code, clientId, secret, callbackUrl, CancellationToken.None);
        }

        private static async Task<TokenHandler> GetTokenAsync(string code, string clientId, string secret, string callbackUrl, CancellationToken cancellationToken)
         {
            cancellationToken.ThrowIfCancellationRequested();
            return await Requester.MakeRequestAsync<TokenHandler>("https://www.deviantart.com/oauth2/token?" +
                                                                  "grant_type=authorization_code&" +
                                                                  $"client_id={clientId}&" +
                                                                  $"client_secret={secret}&" +
                                                                  $"code={code}&" +
                                                                  $"redirect_uri={callbackUrl}", cancellationToken);
        }

        /// <summary>
        /// Retrieve new AccessToken for api and get returned refreshToken
        /// </summary>
        /// <param name="clientId">Id of application</param>
        /// <param name="secret">Secret of application</param>
        /// <param name="callbackUrl">Url where client must be after successful request</param>
        /// <param name="refreshToken">Token gained on previus login</param>
        /// <param name="updated">Function for getting new refresh_token during working process(other requests to site)</param>
        /// <param name="scopes">Scopes for application</param>
        /// <param name="disableAutoAccessTokenChecking">Disable automatic checking accessToken</param>
        /// <returns>Tuple with returned refresh_token, flag for login error and login error message</returns>
        public static Task<LoginResult> SetAccessTokenByRefreshAsync(
            string clientId,
            string secret,
            string callbackUrl,
            string refreshToken,
            RefreshTokenUpdated updated,
            Scope[] scopes = null,
            bool disableAutoAccessTokenChecking = false)
        {
            return SetAccessTokenByRefreshAsync(
                    clientId,
                    secret,
                    callbackUrl,
                    refreshToken,
                    updated,
                    CancellationToken.None,
                    scopes,
                    disableAutoAccessTokenChecking);
        }

        /// <summary>
        /// Retrieve new AccessToken for api and get returned refreshToken
        /// </summary>
        /// <param name="clientId">Id of application</param>
        /// <param name="secret">Secret of application</param>
        /// <param name="callbackUrl">Url where client must be after successful request</param>
        /// <param name="refreshToken">Token gained on previus login</param>
        /// <param name="updated">Function for getting new refresh_token during working process(other requests to site)</param>
        /// <param name="cancellationToken">Token to interrupt executing</param>
        /// <param name="scopes">Scopes for application</param>
        /// <param name="disableAutoAccessTokenChecking">Disable automatic checking accessToken</param>
        /// <returns>Tuple with returned refresh_token, flag for login error and login error message</returns>
        public static async Task<LoginResult> SetAccessTokenByRefreshAsync(
            string clientId,
            string secret,
            string callbackUrl,
            string refreshToken,
            RefreshTokenUpdated updated,
            CancellationToken cancellationToken,
            Scope[] scopes = null,
            bool disableAutoAccessTokenChecking = false)
        {
            TokenHandler tokenHandler = null;
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                tokenHandler =
                    await
                        Requester.MakeRequestAsync<TokenHandler>(
                            "https://www.deviantart.com/oauth2/token?" + "grant_type=refresh_token&"
                            + $"client_id={clientId}&" + $"client_secret={secret}&" + $"refresh_token={refreshToken}",
                            cancellationToken);
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
                /*if (tokenHandler.Error == "invalid_request")
                    return await SignInAsync(clientId, secret, callbackUrl, updated, cancellationToken, scopes);*/
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
            Requester.Updated = updated;
            Requester.Updated?.Invoke(tokenHandler.RefreshToken);
            Requester.RefreshToken = tokenHandler.RefreshToken;
            Requester.AppClientId = clientId;
            Requester.AppSecret = secret;
            Requester.Scopes = scopes;
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

        public static Task<bool> LogoutAsync(string token)
        {
            return LogoutAsync(token, CancellationToken.None);
        }

        public static async Task<bool> LogoutAsync(string token, CancellationToken cancellationToken)
        {
            //not tested yet
            cancellationToken.ThrowIfCancellationRequested();
            return (await
                    Requester.MakeRequestAsync<LogoutStatus>("https://www.deviantart.com/oauth2/revoke",
                        new FormUrlEncodedContent(new[]
                        {
                            new KeyValuePair<string, string>("token", token),
                            new KeyValuePair<string, string>("revoke_refresh_only", "true")
                        }), HttpMethod.Post, cancellationToken)).Success;
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
