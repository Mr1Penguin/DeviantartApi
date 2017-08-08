using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Feed.Home
{
    public class BucketRequest : PageableRequest<Objects.ArrayOfResults<Objects.Deviation>>
    {
        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        public string BucketId { get; set; }

        public BucketRequest(string bucketid)
        {
            BucketId = bucketid;
        }

        public override Task<Response<Objects.ArrayOfResults<Objects.Deviation>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => MatureContent);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"feed/home/{BucketId}?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
