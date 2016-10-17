using System;
using System.Threading.Tasks;

namespace DeviantartApi
{
    public static partial class Login
    {
        public struct SignInResult
        {
            public string Code { get; set; }

            public bool IsSignInError { get; set; }

            public string SignInErrorText { get; set; }

            public string SignInErrorShortText { get; set; }
        }

        public delegate Task<SignInResult> CustomSignIn(string clientId, string secret, string callbackUrl, RefreshTokenUpdated updated, Scope[] scopes = null);

        public static CustomSignIn CustomSignInAsync { get; set; }

        public static async Task<LoginResult> SignInAsync(string clientId, string secret, string callbackUrl, RefreshTokenUpdated updated, Scope[] scopes = null)
        {
            var signInResult = await CustomSignInAsync(clientId, secret, callbackUrl, updated, scopes);
            if (signInResult.IsSignInError)
                return new LoginResult
                {
                    IsLoginError = true,
                    LoginErrorShortText = signInResult.SignInErrorShortText,
                    LoginErrorText = signInResult.SignInErrorText
                };
            var code = signInResult.Code;
            var tokenHandler = await GetTokenAsync(code, clientId, secret, callbackUrl);

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
    }
}
