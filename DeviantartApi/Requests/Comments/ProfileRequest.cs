using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Comments.Profile
{
    using System.Threading;

    public class ProfileRequest : GetCommentsRequest
    {
        public ProfileRequest(string username)
        {
            Argument = username;
        }

        public override Task<Response<Objects.Comments>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => CommentId);
            values.AddParameter(() => MaxDepth);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"comments/profile/{Argument}?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
