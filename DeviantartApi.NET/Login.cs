using System;
using System.Threading.Tasks;

namespace DeviantartApi
{
    public static partial class Login
    {
        public delegate Task<LoginResult> CustomSignIn(string clientId, string secret, string callbackUrl, RefreshTokenUpdated updated, Scope[] scopes = null);

        public static CustomSignIn CustomSignInAsync { get; set; }

        public static async Task<LoginResult> SignInAsync(string clientId, string secret, string callbackUrl, RefreshTokenUpdated updated, Scope[] scopes = null)
        {
            return await CustomSignInAsync(clientId, secret, callbackUrl, updated, scopes);
        }
    }
}