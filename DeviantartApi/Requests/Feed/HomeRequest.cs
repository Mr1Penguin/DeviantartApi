using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Feed
{
    public class HomeRequest : PageableRequest<Objects.ArrayOfItems<Objects.SubObjects.FeedItem>>
    {
        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        public override async Task<Response<Objects.ArrayOfItems<Objects.SubObjects.FeedItem>>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => MatureContent);
            values.AddParameter(() => Cursor);
            return await ExecuteDefaultGetAsync("feed/home?" + values.ToGetParameters());
        }
    }
}
