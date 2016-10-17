using DeviantartApi.Attributes;
using System.Collections.Generic;
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

        [Parameter("user")]
        [Expands]
        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();

        [Parameter("seed")]
        public string Seed { get; set; }

        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        public override async Task<Response<Objects.MltPreview>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddHashSetParameter(() => UserExpands);
            values.AddParameter(() => Seed);
            values.AddParameter(() => MatureContent);
            return await ExecuteDefaultGetAsync("browse/morelikethis/preview?" + values.ToGetParameters());
        }
    }
}
