using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Comments.Status
{
    public class StatusRequest : PageableRequest<Objects.Comments>
    {
        public string CommentId { get; set; }
        public uint MaxDepth { get; set; }

        private string _statusid;

        public StatusRequest(string statusid)
        {
            _statusid = statusid;
        }

        public override async Task<Response<Objects.Comments>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"comments/status/{_statusid}?commentid={CommentId}&maxdepth={MaxDepth}"
                 + (Offset != null ? $"&offset={Offset}" : "") + (Limit != null ? $"&limit={Limit}" : ""));
        }
    }
}
