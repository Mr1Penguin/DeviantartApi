using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Messages
{
    public class FeedRequest : PageableRequest<Objects.ArrayOfResults<Objects.SubObjects.Message>>
    {
        public string FolderId { get; set; }
        public bool Stack { get; set; }

        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.Message>>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"messages/feed?"
                + $"folderid={FolderId}"
                + "&" + $"stack={Stack.ToString().ToLower()}"
                + (Cursor != null ? $"&cursor={Cursor}" : ""));
        }
    }
}
