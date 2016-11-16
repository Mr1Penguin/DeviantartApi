using System;
using System.Threading.Tasks;

namespace DeviantartApi
{
    using System.Threading;

    public static partial class Login
    {
        public struct SignInResult
        {
            public string Code { get; set; }

            public bool IsSignInError { get; set; }

            public string SignInErrorText { get; set; }

            public string SignInErrorShortText { get; set; }
        }

        public delegate Task<SignInResult> CustomSignIn(
            string clientId,
            string secret,
            string callbackUrl,
            RefreshTokenUpdated updated,
            CancellationToken cancellationToken,
            Scope[] scopes = null);

        public static CustomSignIn CustomSignInAsync { get; set; }

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

        public static async Task<LoginResult> SignInAsync(
            string clientId,
            string secret,
            string callbackUrl,
            RefreshTokenUpdated updated,
            CancellationToken cancellationToken,
            Scope[] scopes = null,
            bool disableAutoAccessTokenChecking = false)
        {
            var signInResult = await CustomSignInAsync(clientId, secret, callbackUrl, updated, cancellationToken, scopes);
            if (signInResult.IsSignInError)
                return new LoginResult
                {
                    IsLoginError = true,
                    LoginErrorShortText = signInResult.SignInErrorShortText,
                    LoginErrorText = signInResult.SignInErrorText
                };
            var code = signInResult.Code;
            cancellationToken.ThrowIfCancellationRequested();
            var tokenHandler = await GetTokenAsync(code, clientId, secret, callbackUrl, cancellationToken);
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
