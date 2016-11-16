using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests
{
    public abstract class Request<T> where T : Objects.BaseObject
    {
        private bool _isFirstExpand = true;

        public abstract Task<Response<T>> ExecuteAsync(CancellationToken cancellationToken);

        public virtual async Task<Response<T>> ExecuteAsync()
        {
            return await this.ExecuteAsync(CancellationToken.None);
        }

        protected async Task<Response<T>> ExecuteDefaultGetAsync(string uri)
        {
            return await ExecuteDefaultGetAsync(uri, CancellationToken.None);
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
                return new Response<T>(true, e.Message);
            }
            cancellationToken.ThrowIfCancellationRequested();
            return new Response<T>(result);
        }

        protected async Task<Response<T>> ExecuteDefaultPostAsync(string uri, Dictionary<string, string> values)
        {
            return await ExecuteDefaultPostAsync(uri, values, CancellationToken.None);
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
                return new Response<T>(true, e.Message);
            }
            cancellationToken.ThrowIfCancellationRequested();
            return new Response<T>(result);
        }
    }
}
