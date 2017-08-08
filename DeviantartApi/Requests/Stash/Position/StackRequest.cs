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

        public StackRequest(string stackid, int position)
        {
            StackId = stackid;
            Position = position;
        }

        public override Task<Response<Objects.PostResponse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => Position);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultPostAsync("stash/position/{_stackid}", values, cancellationToken);
        }
    }
}
