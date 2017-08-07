using DeviantartApi.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
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

        public override async Task<Response<Objects.MoveStackResponse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => TargetId);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultPostAsync("stash/move/{_stackid}", values, cancellationToken);
        }
    }
}
