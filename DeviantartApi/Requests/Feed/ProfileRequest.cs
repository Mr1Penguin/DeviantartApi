using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Feed
{
    public class ProfileRequest : PageableRequest<Objects.ArrayOfResults<Objects.SubObjects.ProfileFeedItem>>
    {
        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.ProfileFeedItem>>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"feed/profile?"
                + (Cursor != null ? $"&cursor={Cursor}" : ""));
        }
    }
}
