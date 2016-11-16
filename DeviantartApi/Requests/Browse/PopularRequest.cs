using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse
{
    using System.Threading;

    public class PopularRequest : PageableRequest<Objects.Browse>
    {
        public enum TimeRange
        {
            t8hr,
            t24hr,
            t3days,
            t1week,
            t1month,
            tAlltime
        }

        public enum UserExpand
        {
            Watch
        }

        [Parameter("user")]
        [Expands]
        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();

        [Parameter("timerange")]
        [NoFirstLetterEnum]
        public TimeRange SelectedTimeRange { get; set; } = TimeRange.t24hr;

        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        /// <summary>
        /// Default path: "/"
        /// </summary>
        [Parameter("category_path")]
        public string CategoryPath { get; set; } = "/";

        [Parameter("q")]
        public string Query { get; set; }

        public override async Task<Response<Objects.Browse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => CategoryPath);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            values.AddHashSetParameter(() => UserExpands);
            values.AddParameter(() => MatureContent);
            values.AddParameter(() => Query);
            values.AddParameter(() => SelectedTimeRange);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync("browse/popular?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
