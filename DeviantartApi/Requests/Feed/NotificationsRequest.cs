using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Feed
{
    public class NotificationsRequest : PageableRequest<Objects.ArrayOfResults<Objects.SubObjects.Notification>>
    {
        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.Notification>>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"feed/notifications?"
                + (Cursor != null ? $"&cursor={Cursor}" : ""));
        }
    }
}
