using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DeviantartApi
{
    public static partial class Login
    {
        public delegate void RefreshTokenUpdated(string newRefreshToken);

        public enum Scope
        {
            Basic,
            User,
            Feed,
            Browse,
            BrowseMlt,
            Collection
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

        public static async Task<LoginResult> ClientCredentialsGrantAsync(string clientId, string secret)
        {
            var tokenHandler = await Requester.MakeRequestAsync<TokenHandler>("https://www.deviantart.com/oauth2/token?" +
                                                                              "grant_type=client_credentials&" +
                                                                              $"client_id={clientId}&" +
                                                                              $"client_secret={secret}");
            if (tokenHandler.Error != null) new LoginResult { IsLoginError = true, LoginErrorText = tokenHandler.ErrorDescription, LoginErrorShortText = tokenHandler.Error };
            Requester.AccessToken = tokenHandler.AccessToken;
            Requester.AccessTokenExpire = DateTime.Now.AddSeconds(tokenHandler.ExpiresIn - 100);
            Requester.Updated = null;
            Requester.RefreshToken = tokenHandler.RefreshToken;
            Requester.AppClientId = clientId;
            Requester.AppSecret = secret;
            Requester.Scopes = null;
            Requester.CallbackUrl = null;
            return new LoginResult { IsLoginError = false };
        }

        private static async Task<TokenHandler> GetTokenAsync(string code, string clientId, string secret, string callbackUrl)
        {
            return await Requester.MakeRequestAsync<TokenHandler>("https://www.deviantart.com/oauth2/token?" +
                                                                  "grant_type=authorization_code&" +
                                                                  $"client_id={clientId}&" +
                                                                  $"client_secret={secret}&" +
                                                                  $"code={code}&" +
                                                                  $"redirect_uri={callbackUrl}");
        }

        /// <summary>
        /// Retrieve new AccessToken for api and get returned refreshToken
        /// </summary>
        /// <param name="clientId">Id of application</param>
        /// <param name="secret">Secret of application</param>
        /// <param name="refreshToken">Token gained on previus login</param>
        /// <param name="updated">Function for getting new refresh_token during working process(other requests to site)</param>
        /// <returns>Tuple with returned refresh_token, flag for login error and login error message</returns>
        public static async Task<LoginResult> SetAccessTokenByRefreshAsync(string clientId, string secret, string callbackUrl, string refreshToken, RefreshTokenUpdated updated, Scope[] scopes = null)
        {
            TokenHandler tokenHandler = null;
            try
            {
                tokenHandler =
                    await Requester.MakeRequestAsync<TokenHandler>("https://www.deviantart.com/oauth2/token?" +
                                                                   "grant_type=refresh_token&" +
                                                                   $"client_id={clientId}&" +
                                                                   $"client_secret={secret}&" +
                                                                   $"refresh_token={refreshToken}");
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
                if (tokenHandler.Error == "invalid_request")
                    return await SignInAsync(clientId, secret, callbackUrl, updated, scopes);
                return new LoginResult
                {
                    RefreshToken = null,
                    IsLoginError = true,
                    LoginErrorText = tokenHandler.ErrorDescription
                };
            }

            Requester.AccessToken = tokenHandler.AccessToken;
            Requester.AccessTokenExpire = DateTime.Now.AddSeconds(tokenHandler.ExpiresIn - 100);
            if (Requester.Updated != updated)
                Requester.Updated = updated;
            else
                Requester.Updated?.Invoke(tokenHandler.RefreshToken);
            Requester.RefreshToken = tokenHandler.RefreshToken;
            Requester.AppClientId = clientId;
            Requester.AppSecret = secret;
            Requester.Scopes = scopes;
            Requester.CallbackUrl = callbackUrl;
            return new LoginResult
            {
                RefreshToken = tokenHandler.RefreshToken,
                IsLoginError = false,
                LoginErrorText = null
            };
        }

        public static async Task<string> LogoutAsync(string token)
        {
            //not tested yet
            return (await
                    Requester.MakeRequestAsync<LogoutStatus>("https://www.deviantart.com/oauth2/revoke",
                        new FormUrlEncodedContent(new[]
                        {
                            new KeyValuePair<string, string>("token", token),
                            new KeyValuePair<string, string>("revoke_refresh_only", "true")
                        }))).Status;
        }

        private class LogoutStatus
        {
            [JsonProperty("status")]
            public string Status { get; set; }
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
