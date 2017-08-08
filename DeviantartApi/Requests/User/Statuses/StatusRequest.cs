using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User.Statuses
{
    public class StatusRequest : Request<Objects.Status>
    {
        public string StatusId { get; set; }

        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        public StatusRequest(string statusId)
        {
            StatusId = statusId;
        }

        public override Task<Response<Objects.Status>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => MatureContent);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"user/statuses/{StatusId}?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
