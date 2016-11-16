using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DeviantartApi
{
    using System.Threading;

    public static partial class Login
    {
        /// <summary>
        /// SignIn into system to get refresh_token for getting new access_token on next start
        /// </summary>
        /// <param name="clientId">Id of application</param>
        /// <param name="secret">Secret of application</param>
        /// <param name="callbackUrl">Allowed url used for getting code</param>
        /// <param name="updated">Function for getting new refresh_token during working process(other requests to site)</param>
        /// <param name="scopes">Scopes for client</param>
        /// <param name="disableAutoAccessTokenChecking">Disable automatic checking accessToken</param>
        /// <returns>Tuple with refresh_token, flag for login error and login error message</returns>
        public static async Task<LoginResult> SignInAsync(
            string clientId,
            string secret,
            string callbackUrl,
            RefreshTokenUpdated updated,
            Scope[] scopes = null,
            bool disableAutoAccessTokenChecking = false)
        {
            return
                await
                    SignInAsync(
                        clientId,
                        secret,
                        callbackUrl,
                        updated,
                        CancellationToken.None,
                        scopes,
                        disableAutoAccessTokenChecking);
        }

        /// <summary>
        /// SignIn into system to get refresh_token for getting new access_token on next start
        /// </summary>
        /// <param name="clientId">Id of application</param>
        /// <param name="secret">Secret of application</param>
        /// <param name="callbackUrl">Allowed url used for getting code</param>
        /// <param name="updated">Function for getting new refresh_token during working process(other requests to site)</param>
        /// <param name="cancellationToken">Token to interrupt executing</param>
        /// <param name="scopes">Scopes for client</param>
        /// <param name="disableAutoAccessTokenChecking">Disable automatic checking accessToken</param>
        /// <returns>Tuple with refresh_token, flag for login error and login error message</returns>
        public static async Task<LoginResult> SignInAsync(
            string clientId,
            string secret,
            string callbackUrl,
            RefreshTokenUpdated updated,
            CancellationToken cancellationToken,
            Scope[] scopes = null,
            bool disableAutoAccessTokenChecking = false)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (scopes == null || scopes.Length == 0) scopes = new[] { Scope.Basic };
            var startUrl = "https://www.deviantart.com/oauth2/authorize?response_type=code&client_id=" + clientId +
                           "&redirect_uri=" + callbackUrl + "&scope=" + string.Join(" ", new HashSet<string>(scopes.Select(x => Regex.Replace(x.ToString(), "(\\B[A-Z])", ".$1").ToLower()).ToList()));
            var startUri = new Uri(startUrl);
            var endUri = new Uri(callbackUrl);
            string result = null;
            var loginErrorString = "";
            int attemptsLeft = 3;
            while (attemptsLeft != 0)
            {
                try
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    var webAuthenticationResult =
                        await
                            Windows.Security.Authentication.Web.WebAuthenticationBroker.AuthenticateAsync(
                                Windows.Security.Authentication.Web.WebAuthenticationOptions.None,
                                startUri,
                                endUri).AsTask(cancellationToken);

                    switch (webAuthenticationResult.ResponseStatus)
                    {
                        case Windows.Security.Authentication.Web.WebAuthenticationStatus.Success:
                            result = webAuthenticationResult.ResponseData;
                            break;

                        case Windows.Security.Authentication.Web.WebAuthenticationStatus.ErrorHttp:
                            loginErrorString = webAuthenticationResult.ResponseErrorDetail.ToString();
                            break;

                        case Windows.Security.Authentication.Web.WebAuthenticationStatus.UserCancel:
                            loginErrorString = "User canceled";
                            break;

                        default:
                            loginErrorString = "Unexpected error: " + webAuthenticationResult.ResponseData;
                            break;
                    }
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    --attemptsLeft;
                    loginErrorString = "Unexpected error: " + ex.Message;
                    continue;
                }
                break;
            }
            cancellationToken.ThrowIfCancellationRequested();
            if (result == null)
                return new LoginResult
                {
                    RefreshToken = null,
                    IsLoginError = true,
                    LoginErrorText = loginErrorString
                };

            var code = new Regex(@".*/.*?code=([^/&]+)").Match(result).Groups[1].Value;

            TokenHandler tokenHandler;

            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                tokenHandler = await GetTokenAsync(code, clientId, secret, callbackUrl, cancellationToken);

                if (tokenHandler.Error != null)
                    return new LoginResult
                               {
                                   RefreshToken = null,
                                   IsLoginError = true,
                                   LoginErrorText = tokenHandler.ErrorDescription
                               };
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
            cancellationToken.ThrowIfCancellationRequested();
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
            Requester.AutoAccessTokenCheckingDisabled = disableAutoAccessTokenChecking;
            cancellationToken.ThrowIfCancellationRequested();
            return new LoginResult
            {
                RefreshToken = tokenHandler.RefreshToken,
                IsLoginError = false,
                LoginErrorText = null
            };
        }
    }
}
