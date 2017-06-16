using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Feed
{
    using System.Threading;

    public class NotificationsRequest : PageableRequest<Objects.ArrayOfResults<Objects.SubObjects.Notification>>
    {
        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.Notification>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => Cursor);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"feed/notifications?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
