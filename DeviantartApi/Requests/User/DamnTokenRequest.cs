using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User
{
    public class DamnTokenRequest : Request<Objects.DamnResponse>
    {
        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        public override Task<Response<Objects.DamnResponse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => MatureContent);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync("user/damntoken?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
