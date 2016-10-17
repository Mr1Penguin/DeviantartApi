using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Feed
{
    public class ProfileRequest : PageableRequest<Objects.ArrayOfResults<Objects.SubObjects.ProfileFeedItem>>
    {
        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.ProfileFeedItem>>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            if (Cursor != null) values.AddParameter(() => Cursor); //do I need to check on null in every request?
            return await ExecuteDefaultGetAsync($"feed/profile?" + values.ToGetParameters());
        }
    }
}
