using System.Threading.Tasks;

namespace DeviantartApi.Requests.Data
{
    using System.Threading;

    public class SubmissionRequest : Request<Objects.Information>
    {
        public override async Task<Response<Objects.Information>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"data/submission?", cancellationToken);
        }
    }
}
