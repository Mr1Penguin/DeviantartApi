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
        public int ItemId { get; set; }

        public DeleteRequest(int itemId)
        {
            ItemId = itemId;
        }

        public override async Task<Response<Objects.PostResponse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => ItemId);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultPostAsync("stash/delete", values, cancellationToken);
        }
    }
}
