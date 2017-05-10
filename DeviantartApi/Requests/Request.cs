using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests
{
    using System.Linq;

    public abstract class Request<T> where T : Objects.BaseObject
    {
        public abstract Task<Response<T>> ExecuteAsync(CancellationToken cancellationToken);

        public virtual Task<Response<T>> ExecuteAsync()
        {
            return this.ExecuteAsync(CancellationToken.None);
        }

        protected Task<Response<T>> ExecuteDefaultGetAsync(string uri)
        {
            return ExecuteDefaultGetAsync(uri, CancellationToken.None);
        }

        protected async Task<Response<T>> ExecuteDefaultGetAsync(string uri, CancellationToken cancellationToken)
        {
            T result;
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Requester.CheckTokenAsync(cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
                result =
                    await
                        Requester.MakeRequestAsync<T>(uri + $"&access_token={Requester.AccessToken}", cancellationToken);
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

        protected Task<Response<T>> ExecuteDefaultPostAsync(string uri, Dictionary<string, string> values)
        {
            return ExecuteDefaultPostAsync(uri, values, CancellationToken.None);
        }

        protected async Task<Response<T>> ExecuteDefaultPostAsync(string uri, Dictionary<string, string> values, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            T result;
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Requester.CheckTokenAsync(cancellationToken);
                if (values == null) values = new Dictionary<string, string>();
                values.Add("access_token", Requester.AccessToken);
                HttpContent content = new FormUrlEncodedContent(values);
                cancellationToken.ThrowIfCancellationRequested();
                result = await Requester.MakeRequestAsync<T>(uri, content, HttpMethod.Post, cancellationToken);
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
