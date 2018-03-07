using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash
{
    public class DeleteRequest : Request<Objects.PostResponse>
    {
        public enum Error
        {
            DeviationNotFound = 0
        }

        [Parameter("itemid")]
        public long ItemId { get; set; }

        public DeleteRequest(long itemId)
        {
            ItemId = itemId;
        }

        public override Task<Response<Objects.PostResponse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => ItemId);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultPostAsync("stash/delete", values, cancellationToken);
        }
    }
}
