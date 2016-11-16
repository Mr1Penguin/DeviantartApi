using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash
{
    using System.Threading;

    public class StackRequest : Request<Objects.StashMetadata>
    {
        public enum Error
        {
            StackNotFound = 0
        }

        private string _stackid;

        public StackRequest(string stackid)
        {
            _stackid = stackid;
        }

        public override async Task<Response<Objects.StashMetadata>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"stash/{_stackid}?", cancellationToken);
        }
    }
}
