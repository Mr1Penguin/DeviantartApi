using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Feed
{
    public class NotificationsRequest : PageableRequest<Objects.ArrayOfResults<Objects.SubObjects.Notification>>
    {
        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.Notification>>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => Cursor);
            return await ExecuteDefaultGetAsync($"feed/notifications?" + values.ToGetParameters());
        }
    }
}
