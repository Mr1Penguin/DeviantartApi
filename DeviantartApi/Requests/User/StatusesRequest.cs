using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User
{
    public class StatusesRequest : PageableRequest<Objects.ArrayOfResults<Objects.Status>>
    {
        [Parameter("username")]
        public string Username { get; set; }

        [Parameter("mature_contetn")]
        public bool MatureContent { get; set; }

        public StatusesRequest(string username)
        {
            Username = username;
        }

        public override Task<Response<Objects.ArrayOfResults<Objects.Status>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => Username);
            values.AddParameter(() => MatureContent);
            values.AddParameter(() => Offset);
            values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync("user/statuses/?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
