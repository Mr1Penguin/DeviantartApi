using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Comments.Post.Profile
{
    public class UsernameRequest : Request<Objects.Comment>
    {
        private string _username;

        public string CommentId { get; set; }
        public string Body { get; set; }

        public UsernameRequest(string username)
        {
            _username = username;
        }

        public override async Task<Response<Objects.Comment>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("body", Body);
            values.Add("commentid", CommentId);
            return await ExecuteDefaultPostAsync($"comments/post/profile/{_username}", values);
        }
    }
}
