using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DeviantartApi.Objects;

namespace DeviantartApi.Requests.Comments.Post.Deviation
{
    public class DeviationRequest : Request<Objects.Comment>
    {
        private string _deviationId;

        public string CommentId { get; set; }
        public string Body { get; set; }

        public DeviationRequest(string deviationId)
        {
            _deviationId = deviationId;
        }

        public override async Task<Response<Objects.Comment>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("body", Body);
            values.Add("commentid", CommentId);
            return await ExecuteDefaultPostAsync($"comments/post/deviation/{_deviationId}", values);
        }
    }
}
