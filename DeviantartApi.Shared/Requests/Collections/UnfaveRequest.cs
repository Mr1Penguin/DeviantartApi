using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Collections
{
    using System.Threading;

    public class UnfaveRequest : Request<Objects.Fave>
    {
        [Parameter("deviationid")]
        public string DeviationId { get; set; }

        [Parameter("folderid")]
        public HashSet<string> FolderIds { get; set; } = new HashSet<string>();

        public override async Task<Response<Objects.Fave>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => DeviationId);
            values.AddHashSetParameter(() => FolderIds);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultPostAsync("collections/unfave", values, cancellationToken);
        }
    }
}
