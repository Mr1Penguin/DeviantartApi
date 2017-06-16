using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash
{
    using System.Threading;

    public class DeleteRequest : Request<Objects.BaseObject>
    {
        public enum Error
        {
            DeviationNotFound = 0
        }

        [Parameter("itemid")]
        public int ItemId { get; set; }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => ItemId);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultPostAsync("stash/delete", values, cancellationToken);
        }
    }
}
