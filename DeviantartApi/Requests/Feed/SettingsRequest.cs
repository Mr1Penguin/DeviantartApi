using System.Threading.Tasks;

namespace DeviantartApi.Requests.Feed
{
    using System.Threading;

    public class SettingsRequest : Request<Objects.FeedSettings>
    {
        public override async Task<Response<Objects.FeedSettings>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"feed/settings?", cancellationToken);
        }
    }
}
