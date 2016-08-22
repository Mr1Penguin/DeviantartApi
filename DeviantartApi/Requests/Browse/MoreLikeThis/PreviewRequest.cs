using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse.MoreLikeThis
{
    public class PreviewRequest : Request<Objects.MltPreview>
    {
        public enum Error
        {
            InvalidSeedRequested = 0
        }

        public enum UserExpand
        {
            Watch
        }

        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();
        public string Seed { get; set; }
        public bool LoadMature { get; set; }

        public override async Task<Response<Objects.MltPreview>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync("browse/morelikethis/preview?" +
                                                $"seed={Seed}" +
                                                $"&expand={string.Join(",", UserExpands.Select(x => "user." + x.ToString().ToLower()).ToList())}" +
                                                $"&mature_content={LoadMature.ToString().ToLower()}");
        }
    }
}
