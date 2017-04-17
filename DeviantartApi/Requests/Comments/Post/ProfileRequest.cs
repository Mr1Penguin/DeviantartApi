using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Comments.Post
{
    using System.Threading;

    public class ProfileRequest : PostCommentRequest
    {
        public ProfileRequest(string username)
        {
            Argument = username;
        }

        public override Task<Response<Objects.Comment>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => Body);
            values.AddParameter(() => CommentId);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultPostAsync($"comments/post/profile/{Argument}", values, cancellationToken);
        }
    }
}
