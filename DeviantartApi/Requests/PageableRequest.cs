using System.Threading.Tasks;

namespace DeviantartApi.Requests
{
    public abstract class PageableRequest<T> : Request<T>
        where T : Objects.Pageable
    {
        public string Cursor { get; set; }
        public uint? Offset { get; set; }
        public uint? Limit { get; set; }
        public uint? PrevOffset { get; set; }

        public virtual async Task<Response<T>> GetNextPageAsync()
        {
            var result = await ExecuteAsync();
            if (!result.IsError && result.Object.HasMore)
            {
                Cursor = result.Object.Cursor;
                if (result.Object.HasLess)
                    PrevOffset = (uint?)result.Object.PrevOffset;
                Offset = (uint?)result.Object.NextOffset;
            }
            return result;
        }

        public virtual async Task<Response<T>> GetPrevPageAsync()
        {
            Offset = PrevOffset;
            var result = await GetNextPageAsync();
            return result;
        }
    }
}
