using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash.Move
{
    class StackRequest : Request<Objects.MoveStackResponse>
    {
        public enum Error
        {
            StackNotFound = 0,
            InvalidTargetStack = 1
        }

        [Parameter("targetid")]
        public string TargetId { get; set; }

        public string StackId { get; set; }

        public StackRequest(string stackid)
        {
            StackId = stackid;
        }

        public override Task<Response<Objects.MoveStackResponse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => TargetId);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultPostAsync("stash/move/{_stackid}", values, cancellationToken);
        }
    }
}
