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

        public override Task<Response<Objects.ArrayOfResults<Objects.Message>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => Offset);
            values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"messages/mentions/{StackId}?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
