using System.Threading.Tasks;

namespace DeviantartApi.Requests
{
    public abstract class PageableRequest<T> : Request<T>
        where T : Objects.Pageable
    {
        public string Cursor { get; set; }

        public async Task<Response<T>> GetNextPageAsync()
        {
            var result = await ExecuteAsync();
            if (!result.IsError)
            {
                Cursor = result.Object.Cursor;
            }
            return result;
        }
    }
}
