using System;
using System.Threading.Tasks;

namespace DeviantartApi.Requests
{
    public abstract class Request<T> where T : Objects.BaseObject
    {
        public abstract Task<Response<T>> ExecuteAsync();
        protected async Task<Response<T>> ExecuteDefaultAsync(string uri)
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
    }
}
