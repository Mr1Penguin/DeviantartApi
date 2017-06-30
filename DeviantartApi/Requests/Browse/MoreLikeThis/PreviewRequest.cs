using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse.MoreLikeThis
{
    using System.Threading;

    public class PreviewRequest : Request<Objects.MltPreview>
    {
        public enum ErrorCode
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

        public override Task<Response<Objects.MltPreview>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddHashSetParameter(() => UserExpands);
            values.AddParameter(() => Seed);
            values.AddParameter(() => MatureContent);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync("browse/morelikethis/preview?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
