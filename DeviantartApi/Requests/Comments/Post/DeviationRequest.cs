using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Comments.Post
{
    public class DeviationRequest : Request<Objects.Comment>
    {
        private string _deviationId;

        [Parameter("commentid")]
        public string CommentId { get; set; }

        [Parameter("body")]
        public string Body { get; set; }

        public DeviationRequest(string deviationId)
        {
            _deviationId = deviationId;
        }

        public override async Task<Response<Objects.Comment>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => Body);
            values.AddParameter(() => CommentId);
            return await ExecuteDefaultPostAsync($"comments/post/deviation/{_deviationId}", values);
        }
    }
}
