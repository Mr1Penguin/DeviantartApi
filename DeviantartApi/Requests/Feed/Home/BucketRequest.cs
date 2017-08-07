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

        private string _bucketid;

        public BucketRequest(string bucketid)
        {
            _bucketid = bucketid;
        }

        public override async Task<Response<Objects.ArrayOfResults<Objects.Deviation>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => MatureContent);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"feed/home/{_bucketid}?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
