using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using DeviantartApi;
using static DeviantartApi.Login;

namespace DeviantartApiLogin.WinForms
{
    public static partial class Login
    {
        public static Task<LoginResult> SignInAsync(
            string clientId,
            string secret,
            Uri callbackUrl,
            Action<string> updated,
            Scope[] scopes = null,
            bool disableAutoAccessTokenChecking = false)
        {
            return SignInAsync(clientId, secret, callbackUrl, updated, CancellationToken.None, scopes, disableAutoAccessTokenChecking);
        }

        public static Task<LoginResult> SignInAsync(
            string clientId,
            string secret,
            Uri callbackUrl,
            Action<string> updated,
            CancellationToken cancellationToken,
            Scope[] scopes = null,
            bool disableAutoAccessTokenChecking = false)
        {
            DeviantartApi.Login.CustomSignInAsync = LoginAsync;
            return DeviantartApi.Login.SignInAsync(clientId, secret, callbackUrl, updated, scopes, disableAutoAccessTokenChecking, cancellationToken);
        }

        private static Task<SignInResult> LoginAsync(
            string clientId,
            string secret,
            Uri callbackUrl,
            Action<string> updated,
            CancellationToken cancellationToken,
            Scope[] scopes = null)
        {
            string code;
            using (var form = new DeviantArtAuthForm(clientId, callbackUrl, scopes?.Select(x => Regex.Replace(x.ToString(), "(\\B[A-Z])", ".$1").ToLower()))) {
                form.ShowDialog();
                if (form.Code == null) {
                    return Task.FromResult(new SignInResult
                    {
                        Code = null,
                        IsSignInError = true,
                        SignInErrorText = "User canceled"
                    });
                } else {
                    code = form.Code;
                }
            }

            return Task.FromResult(new SignInResult { Code = code });
        }
    }
}
