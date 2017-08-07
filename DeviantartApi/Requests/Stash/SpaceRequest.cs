using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash
{
    using System.Threading;

    public class SpaceRequest : Request<Objects.Space>
    {
        public override async Task<Response<Objects.Space>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"stash/space?", cancellationToken);
        }
    }
}
