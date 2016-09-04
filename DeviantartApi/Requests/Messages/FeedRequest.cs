using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Messages
{
    public class FeedRequest : PageableRequest<Objects.MessagesFeed>
    {
        public string FolderId { get; set; }
        public bool Stack { get; set; }

        public override async Task<Response<Objects.MessagesFeed>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"messages/feed?"
                + $"folderid={FolderId}"
                + "&" + $"stack={Stack.ToString().ToLower()}"
                + (Cursor != null ? $"&cursor={Cursor}" : ""));
        }
    }
}
