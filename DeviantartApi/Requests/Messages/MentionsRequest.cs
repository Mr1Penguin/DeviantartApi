using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Messages
{
    public class MentionsRequest : PageableRequest<Objects.ArrayOfResults<Objects.SubObjects.Message>>
    {
        public string FolderId { get; set; }
        public bool Stack { get; set; }

        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.Message>>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"messages/mentions?"
                + $"folderid={FolderId}"
                + "&" + $"stack={Stack.ToString().ToLower()}"
                + (Offset != null ? $"&offset={Offset}" : "") + (Limit != null ? $"&limit={Limit}" : ""));
        }
    }
}
