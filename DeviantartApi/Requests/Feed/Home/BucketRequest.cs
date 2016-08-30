using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Feed.Home
{
    public class BucketRequest : PageableRequest<Objects.Deviations>
    {
        public bool MatureContent { get; set; }

        private string _bucketid;

        public BucketRequest(string bucketid)
        {
            _bucketid = bucketid;
        }

        public override async Task<Response<Objects.Deviations>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"feed/home/{_bucketid}?"
                + $"mature_content={MatureContent.ToString().ToLower()}"
                + (Offset != null ? $"&offset={Offset}" : "") + (Limit != null ? $"&limit={Limit}" : ""));
        }
    }
}
