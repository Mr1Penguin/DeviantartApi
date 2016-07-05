using System;
using System.Threading.Tasks;

namespace DeviantartApi
{
    public static partial class Login
    {
        public static async Task<LoginResult> SignInAsync(string clientId, string secret, string callbackUrl, RefreshTokenUpdated updated, Scope[] scopes = null)
        {
            throw new NotImplementedException();
        }
    }
}
