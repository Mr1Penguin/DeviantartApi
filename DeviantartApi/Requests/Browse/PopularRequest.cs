using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse
{
    /// <summary>
    /// Browse popular deviations
    /// </summary>
    public class PopularRequest : BrowseRequest
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

        /// <summary>
        /// The timerange
        /// </summary>
        [Parameter("timerange")]
        [NoFirstLetterEnum]
        public TimeRange SelectedTimeRange { get; set; } = TimeRange.t24hr;

        /// <summary>
        /// Search query term
        /// </summary>
        [Parameter("q")]
        public string Query { get; set; }

        public override Task<Response<Objects.Browse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => CategoryPath);
            values.AddParameter(() => Offset);
            values.AddParameter(() => Limit);
            values.AddHashSetParameter(() => UserExpands);
            values.AddParameter(() => MatureContent);
            values.AddParameter(() => Query);
            values.AddParameter(() => SelectedTimeRange);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync("browse/popular?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
