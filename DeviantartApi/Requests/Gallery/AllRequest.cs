using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace DeviantartApi.Requests.Gallery
{
    public class AllRequest : PageableRequest<Objects.ArrayOfResults<Objects.Deviation>>
    {
        [Parameter("username")]
        public string Username { get; set; }

        public override Task<Response<Objects.ArrayOfResults<Objects.Deviation>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => Username);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"gallery/all?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
