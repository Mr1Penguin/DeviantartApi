using DeviantartApi.Attributes;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests
{

    public abstract class PageableRequest<T> : Request<T>
        where T : Objects.Pageable
    {
        [Parameter("cursor")]
        public string Cursor { get; set; }

        [Parameter("offset")]
        public uint? Offset { get; set; }

        [Parameter("limit")]
        public uint? Limit { get; set; }

        public uint? PrevOffset { get; set; }

        public virtual async Task<Response<T>> GetNextPageAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await ExecuteAsync();
            if (!result.IsError && result.Object.HasMore)
            {
                cancellationToken.ThrowIfCancellationRequested();
                Cursor = result.Object.Cursor;
                if (result.Object.HasLess)
                    PrevOffset = (uint?)result.Object.PrevOffset;
                Offset = (uint?)result.Object.NextOffset;
            }
            cancellationToken.ThrowIfCancellationRequested();
            return result;
        }

        public virtual Task<Response<T>> GetNextPageAsync()
        {
            return GetNextPageAsync(CancellationToken.None);
        }

        public virtual async Task<Response<T>> GetPrevPageAsync(CancellationToken cancellationToken)
        {
            Offset = PrevOffset;
            cancellationToken.ThrowIfCancellationRequested();
            var result = await GetNextPageAsync(cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            return result;
        }

        public virtual Task<Response<T>> GetPrevPageAsync()
        {
            return GetNextPageAsync(CancellationToken.None);
        }
    }
}
