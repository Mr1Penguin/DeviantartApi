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

        /// <summary>
        /// The pagination offset
        /// </summary>
        [Parameter("offset")]
        public uint? Offset { get; set; }

        /// <summary>
        /// The pagination limit
        /// </summary>
        [Parameter("limit")]
        public uint? Limit { get; set; }

        public uint? PrevOffset { get; set; }

        public virtual async Task<Response<T>> GetNextPageAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await ExecuteAsync().ConfigureAwait(false);
            if (!result.IsError && result.Result.HasMore)
            {
                cancellationToken.ThrowIfCancellationRequested();
                Cursor = result.Result.Cursor;
                if (result.Result.HasLess)
                    PrevOffset = (uint?)result.Result.PrevOffset;
                Offset = (uint?)result.Result.NextOffset;
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
            var result = await GetNextPageAsync(cancellationToken).ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested();
            return result;
        }

        public virtual Task<Response<T>> GetPrevPageAsync()
        {
            return GetNextPageAsync(CancellationToken.None);
        }
    }
}
