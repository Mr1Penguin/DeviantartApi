using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Comments.Profile
{
    public class UsernameRequest : PageableRequest<Objects.Comments>
    {
        public string CommentId { get; set; }
        public uint MaxDepth { get; set; }

        private string _username;

        public UsernameRequest(string username)
        {
            _username = username;
        }

        public override async Task<Response<Objects.Comments>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"comments/profile/{_username}?commentid={CommentId}&maxdepth={MaxDepth}"
                + (Offset != null ? $"&offset={Offset}" : "") + (Limit != null ? $"&limit={Limit}" : ""));
        }
    }
}
