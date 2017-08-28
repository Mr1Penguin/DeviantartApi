using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests
{
    public abstract class Request<T> where T : Objects.BaseObject
    {
        protected string MajorVersion { get; set; } = "1";

        protected Uri BasePath => new Uri($"https://www.deviantart.com/api/v{MajorVersion}/oauth2/");

        public abstract Task<Response<T>> ExecuteAsync(CancellationToken cancellationToken);

        public virtual Task<Response<T>> ExecuteAsync()
        {
            return ExecuteAsync(CancellationToken.None);
        }

        protected Task<Response<T>> ExecuteDefaultGetAsync(string path)
        {
            return ExecuteDefaultGetAsync(path, CancellationToken.None);
        }

        protected async Task<Response<T>> ExecuteDefaultGetAsync(string path, CancellationToken cancellationToken)
        {
            T result;
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Requester.CheckTokenAsync(cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                var uri = new Uri(BasePath, path + $"&access_token={Requester.AccessToken}");
                result = await Requester.MakeRequestAsync<T>(uri, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (result.Error != null)
                {
                    return new Response<T>(true, result.ErrorDescription);
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var message =
                    e.InnerException?.Message.Split('\r', '\n')
                        .FirstOrDefault(
                            s =>
                                !string.IsNullOrWhiteSpace(s)
                                && s != "The text associated with this error code could not be found.") ?? e.Message;
                return new Response<T>(true, message);
            }
            cancellationToken.ThrowIfCancellationRequested();
            return new Response<T>(result);
        }

        protected Task<Response<T>> ExecuteDefaultPostAsync(string path, Dictionary<string, string> values)
        {
            return ExecuteDefaultPostAsync(path, values, CancellationToken.None);
        }

        protected async Task<Response<T>> ExecuteDefaultPostAsync(string path, Dictionary<string, string> values, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            T result;
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Requester.CheckTokenAsync(cancellationToken).ConfigureAwait(false);
                if (values == null) values = new Dictionary<string, string>();
                values.Add("access_token", Requester.AccessToken);
                HttpContent content = new FormUrlEncodedContent(values);
                cancellationToken.ThrowIfCancellationRequested();
                var uri = new Uri(BasePath, path);
                result = await Requester.MakeRequestAsync<T>(uri, content, method: HttpMethod.Post, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (result.Error != null)
                {
                    return new Response<T>(true, result.ErrorDescription);
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var message =
                    e.InnerException?.Message.Split('\r', '\n')
                        .FirstOrDefault(
                            s =>
                                !string.IsNullOrWhiteSpace(s)
                                && s != "The text associated with this error code could not be found.") ?? e.Message;
                return new Response<T>(true, message);
            }
            cancellationToken.ThrowIfCancellationRequested();
            return new Response<T>(result);
        }
    }
}
