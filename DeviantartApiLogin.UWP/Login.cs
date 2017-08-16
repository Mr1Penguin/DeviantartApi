using DeviantartApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Core;
using static DeviantartApi.Login;

namespace DeviantartApiLogin.UWP
{
    public static class Login
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

        private static async Task<SignInResult> LoginAsync(
            string clientId,
            string secret,
            Uri callbackUrl,
            Action<string> updated,
            CancellationToken cancellationToken,
            Scope[] scopes = null)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (scopes == null || scopes.Length == 0) scopes = new[] { Scope.Basic };
            var startUrl = "https://www.deviantart.com/oauth2/authorize?response_type=code&client_id=" + clientId +
                           "&redirect_uri=" + callbackUrl + "&scope=" + string.Join(" ", new HashSet<string>(scopes.Select(x => Regex.Replace(x.ToString(), "(\\B[A-Z])", ".$1").ToLower()).ToList()));
            var startUri = new Uri(startUrl);
            string result = null;
            var loginErrorString = "";
            var attemptsLeft = 3;
            while (attemptsLeft != 0)
            {
                try
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    Windows.Security.Authentication.Web.WebAuthenticationResult webAuthenticationResult = null;
                    var coreDispatcher = Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher;
                    webAuthenticationResult = await coreDispatcher.RunTaskAsync(() =>
                            Windows.Security.Authentication.Web.WebAuthenticationBroker.AuthenticateAsync(
                                Windows.Security.Authentication.Web.WebAuthenticationOptions.None,
                                startUri,
                                callbackUrl).AsTask(cancellationToken)).ConfigureAwait(true);

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
                    await Task.Delay(100);
                    continue;
                }
                break;
            }
            cancellationToken.ThrowIfCancellationRequested();
            if (result == null)
            {
                return new SignInResult
                {
                    Code = null,
                    IsSignInError = true,
                    SignInErrorText = loginErrorString
                };
            }

            var code = new Regex(@".*/.*?code=([^/&]+)").Match(result).Groups[1].Value;

            return new SignInResult { Code = code };

        }

        private static async Task<T> RunTaskAsync<T>(this CoreDispatcher dispatcher,
           Func<Task<T>> func, CoreDispatcherPriority priority = CoreDispatcherPriority.Normal)
        {
            var taskCompletionSource = new TaskCompletionSource<T>();
            await dispatcher.RunAsync(priority, async () =>
            {
                try
                {
                    taskCompletionSource.SetResult(await func().ConfigureAwait(true));
                }
                catch (Exception ex)
                {
                    taskCompletionSource.SetException(ex);
                }
            });
            return await taskCompletionSource.Task.ConfigureAwait(true);
        }
    }
}
