using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash.Update
{
    public class StackRequest : Request<Objects.PostResponse>
    {
        public enum Error
        {
            StackNotFound = 0
        }

        [Parameter("title")]
        public string Title { get; set; }

        [Parameter("description")]
        public string Description { get; set; }

        public string StackId { get; set; }

        public StackRequest(string stackid)
        {
            StackId = stackid;
        }

        public override Task<Response<Objects.PostResponse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => Title);
            values.AddParameter(() => Description);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultPostAsync($"stash/update/{StackId}", values, cancellationToken);
        }
    }
}
