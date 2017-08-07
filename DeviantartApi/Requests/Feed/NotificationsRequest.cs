using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Feed
{
    public class NotificationsRequest : PageableRequest<Objects.ArrayOfResults<Objects.Notification>>
    {
        public override async Task<Response<Objects.ArrayOfResults<Objects.Notification>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => Cursor);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"feed/notifications?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
