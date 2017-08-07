using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash
{
    public class StackRequest : Request<Objects.StashMetadata>
    {
        public enum Error
        {
            StackNotFound = 0
        }

        public string StackId { get; set; }

        public StackRequest(string stackid)
        {
            StackId = stackid;
        }

        public override async Task<Response<Objects.StashMetadata>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"stash/{StackId}?", cancellationToken);
        }
    }
}
