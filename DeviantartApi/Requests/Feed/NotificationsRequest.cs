using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Feed
{
    public class NotificationsRequest : PageableRequest<Objects.ArrayOfItems<Objects.Notification>>
    {
        public override Task<Response<Objects.ArrayOfItems<Objects.Notification>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => Cursor);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"feed/notifications?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
