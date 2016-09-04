using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Messages
{
    public class FeedbackRequest : PageableRequest<Objects.ArrayOfResults<Objects.SubObjects.Message>>
    {
        public enum MessagesType
        {
            Comments,
            Replies,
            Activity
        }

        public MessagesType Type { get; set; }
        public string FolderId { get; set; }
        public bool Stack { get; set; }

        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.Message>>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"messages/feedback?"
                + $"type={Type.ToString().ToLower()}"
                + "&" + $"folderid={FolderId}"
                + "&" + $"stack={Stack.ToString().ToLower()}"
                + (Offset != null ? $"&offset={Offset}" : "") + (Limit != null ? $"&limit={Limit}" : ""));
        }
    }
}
