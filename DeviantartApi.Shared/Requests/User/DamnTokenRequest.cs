using System.Threading.Tasks;

namespace DeviantartApi.Requests.User
{
    using System.Threading;

    internal class DamnTokenRequest : Request<Objects.DamnResponse>
    {
        public override async Task<Response<Objects.DamnResponse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync("user/damntoken", cancellationToken);
        }
    }
}
