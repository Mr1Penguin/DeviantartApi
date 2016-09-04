using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Messages
{
    public class MentionsRequest : PageableRequest<Objects.MessagesFeed>
    {
        public string FolderId { get; set; }
        public bool Stack { get; set; }

        public override async Task<Response<Objects.MessagesFeed>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"messages/mentions?"
                + $"folderid={FolderId}"
                + "&" + $"stack={Stack.ToString().ToLower()}"
                + (Offset != null ? $"&offset={Offset}" : "") + (Limit != null ? $"&limit={Limit}" : ""));
        }
    }
}
