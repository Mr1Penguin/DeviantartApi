using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Messages
{
    public class FeedbackRequest : PageableRequest<Objects.ArrayOfResults<Objects.SubObjects.Message>>
    {
        public string FolderId { get; set; }

        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.Message>>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"messages/feedback?"
                + $"folderid={FolderId}"
                + (Offset != null ? $"&offset={Offset}" : "") + (Limit != null ? $"&limit={Limit}" : ""));
        }
    }
}
