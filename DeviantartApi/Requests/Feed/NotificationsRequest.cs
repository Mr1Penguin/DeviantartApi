using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Feed
{
    public class NotificationsRequest : PageableRequest<Objects.Notifications>
    {
        public override async Task<Response<Objects.Notifications>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"feed/notifications?"
                + 
                + (Cursor != null ? $"&cursor={Cursor}" : ""));
        }
    }
}
