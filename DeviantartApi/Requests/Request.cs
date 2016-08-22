using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DeviantartApi.Requests
{
    public abstract class Request<T> where T : Objects.BaseObject
    {
        public abstract Task<Response<T>> ExecuteAsync();

        protected async Task<Response<T>> ExecuteDefaultGetAsync(string uri)
        {
            T result;
            try
            {
                await Requester.CheckTokenAsync();
                result =
                    await
                        Requester.MakeRequestAsync<T>(uri + $"&access_token={Requester.AccessToken}");
            }
            catch (Exception e)
            {
                return new Response<T>(true, e.Message);
            }
            return new Response<T>(result);
        }

        protected async Task<Response<T>> ExecuteDefaultPostAsync(string uri, Dictionary<string, string> values)
        {
            T result;
            try
            {
                await Requester.CheckTokenAsync();
                if (values == null)
                    values = new Dictionary<string, string>();
                values.Add("access_token", Requester.AccessToken);
                HttpContent content = new FormUrlEncodedContent(values);
                result =
                    await
                        Requester.MakeRequestAsync<T>(uri, content, HttpMethod.Post);
            }
            catch (Exception e)
            {
                return new Response<T>(true, e.Message);
            }
            return new Response<T>(result);
        }
    }
}
