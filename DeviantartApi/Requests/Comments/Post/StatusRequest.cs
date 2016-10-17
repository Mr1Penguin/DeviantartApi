using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Comments.Post
{
    public class StatusRequest : Request<Objects.Comment>
    {
        private string _statusId;

        [Parameter("commentid")]
        public string CommentId { get; set; }

        [Parameter("body")]
        public string Body { get; set; }

        public StatusRequest(string statusId)
        {
            _statusId = statusId;
        }

        public override async Task<Response<Objects.Comment>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => Body);
            values.AddParameter(() => CommentId);
            return await ExecuteDefaultPostAsync($"comments/post/status/{_statusId}", values);
        }
    }
}
