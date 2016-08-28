using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Feed
{
    public class SettingsRequest : Request<Objects.FeedSettings>
    {
        public override async Task<Response<Objects.FeedSettings>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"feed/settings?");
        }
    }
}
