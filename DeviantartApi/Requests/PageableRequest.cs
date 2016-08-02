using System.Threading.Tasks;

namespace DeviantartApi.Requests
{
    public abstract class PageableRequest<T> : Request<T>
        where T : Objects.Pageable
    {
        public string Cursor { get; set; }
        public uint? Offset { get; set; }

        public virtual async Task<Response<T>> GetNextPageAsync()
        {
            var result = await ExecuteAsync();
            if (!result.IsError && result.Object.HasMore)
            {
                Cursor = result.Object.Cursor;
                Offset = (uint?)result.Object.NextOffset;
            }
            return result;
        }
    }
}
