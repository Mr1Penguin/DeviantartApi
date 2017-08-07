using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Messages.Mentions
{
    public class StackRequest : PageableRequest<Objects.ArrayOfResults<Objects.Message>>
    {
        public string StackId { get; set; }

        public StackRequest(string stackid)
        {
            StackId = stackid;
        }

        public override async Task<Response<Objects.ArrayOfResults<Objects.Message>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"messages/mentions/{StackId}?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
