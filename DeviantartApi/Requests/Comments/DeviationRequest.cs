using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Comments
{
    using System.Threading;

    public class DeviationRequest : GetCommentsRequest
    {
        public DeviationRequest(string deviationId)
        {
            Argument = deviationId;
        }

        public override Task<Response<Objects.Comments>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => CommentId);
            values.AddParameter(() => MaxDepth);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"comments/deviation/{Argument}?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
