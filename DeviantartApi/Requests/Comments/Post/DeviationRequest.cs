using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Comments.Post
{
    public class DeviationRequest : PostCommentRequest
    {
        public DeviationRequest(string deviationId)
        {
            Argument = deviationId;
        }

        public override Task<Response<Objects.Comment>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => Body);
            values.AddParameter(() => CommentId);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultPostAsync($"comments/post/deviation/{Argument}", values, cancellationToken);
        }
    }
}
