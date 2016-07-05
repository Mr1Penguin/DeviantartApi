using System.Threading.Tasks;

namespace DeviantartApi.Requests
{
    public abstract class Request<T>
    {
        public abstract Task<Response<T>> ExecuteAsync();
    }
}
