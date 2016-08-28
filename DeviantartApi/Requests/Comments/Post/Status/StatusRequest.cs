using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Comments.Post.Status
{
    public class StatusRequest : Request<Objects.Comment>
    {
        private string _statusId;

        public string CommentId { get; set; }
        public string Body { get; set; }

        public StatusRequest(string statusId)
        {
            _statusId = statusId;
        }

        public override async Task<Response<Objects.Comment>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("body", Body);
            values.Add("commentid", CommentId);
            return await ExecuteDefaultPostAsync($"comments/post/status/{_statusId}", values);
        }
    }
}
