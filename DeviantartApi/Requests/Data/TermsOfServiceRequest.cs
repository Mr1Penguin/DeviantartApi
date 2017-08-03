using System.Threading.Tasks;

namespace DeviantartApi.Requests.Data
{
    using System.Threading;

    public class TermsOfServiceRequest : Request<Objects.Information>
    {
        public override async Task<Response<Objects.Information>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"data/tos?", cancellationToken);
        }
    }
}
