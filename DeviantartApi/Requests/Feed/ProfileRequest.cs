using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Feed
{
    public class ProfileRequest : PageableRequest<Objects.ArrayOfResults<Objects.ProfileFeedItem>>
    {
        public override Task<Response<Objects.ArrayOfResults<Objects.ProfileFeedItem>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => Cursor);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"feed/profile?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
