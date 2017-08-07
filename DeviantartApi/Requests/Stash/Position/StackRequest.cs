using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash.Position
{
    public class StackRequest : Request<Objects.PostResponse>
    {
        [Parameter("position")]
        public int Position { get; set; }

        public string StackId { get; set; }

        public StackRequest(string stackid)
        {
            StackId = stackid;
        }

        public override async Task<Response<Objects.PostResponse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => Position);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultPostAsync("stash/position/{_stackid}", values, cancellationToken);
        }
    }
}
