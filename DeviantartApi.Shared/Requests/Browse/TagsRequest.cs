using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse
{
    using System.Threading;

    public class TagsRequest : PageableRequest<Objects.Browse>
    {
        public enum UserExpand
        {
            Watch
        }

        [Parameter("user")]
        [Expands]
        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();

        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        [Parameter("tag")]
        public string Tag { get; set; }

        public override async Task<Response<Objects.Browse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            values.AddHashSetParameter(() => UserExpands);
            values.AddParameter(() => MatureContent);
            values.AddParameter(() => Tag);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync("browse/tags?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
