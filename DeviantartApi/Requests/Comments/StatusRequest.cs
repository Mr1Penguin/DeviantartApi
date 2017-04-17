using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Comments.Status
{
    using System.Threading;

    public class StatusRequest : CommentsRequest
    {
        public StatusRequest(string statusid)
        {
            Argument = statusid;
        }

        public override Task<Response<Objects.Comments>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => CommentId);
            values.AddParameter(() => MaxDepth);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"comments/status/{Argument}?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
