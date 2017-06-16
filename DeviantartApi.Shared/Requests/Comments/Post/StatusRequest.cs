using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Comments.Post
{
    using System.Threading;

    public class StatusRequest : PostCommentRequest
    {
        public StatusRequest(string statusId)
        {
            Argument = statusId;
        }

        public override Task<Response<Objects.Comment>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => Body);
            values.AddParameter(() => CommentId);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultPostAsync($"comments/post/status/{Argument}", values, cancellationToken);
        }
    }
}
