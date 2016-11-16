using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash.Publish
{
    using System.Threading;

    public class UserDataRequest : Request<Objects.UserData>
    {
        public override async Task<Response<Objects.UserData>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"stash/publish/userdata?", cancellationToken);
        }
    }
}
