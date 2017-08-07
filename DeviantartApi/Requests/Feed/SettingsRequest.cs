using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Feed
{
    public class SettingsRequest : Request<Objects.FeedSettings>
    {
        public override async Task<Response<Objects.FeedSettings>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"feed/settings?", cancellationToken);
        }
    }
}
