using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Feed
{
    public class ProfileRequest : PageableRequest<Objects.ProfileFeed>
    {
        public override async Task<Response<Objects.ProfileFeed>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"feed/profile?"
                + 
                + (Cursor != null ? $"&cursor={Cursor}" : ""));
        }
    }
}
