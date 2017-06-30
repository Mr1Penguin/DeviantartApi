using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse
{
    using System.Threading;

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

        [Parameter("timerange")]
        [NoFirstLetterEnum]
        public TimeRange SelectedTimeRange { get; set; } = TimeRange.t24hr;

        [Parameter("q")]
        public string Query { get; set; }

        public override Task<Response<Objects.Browse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => CategoryPath);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            values.AddHashSetParameter(() => UserExpands);
            values.AddParameter(() => MatureContent);
            values.AddParameter(() => Query);
            values.AddParameter(() => SelectedTimeRange);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync("browse/popular?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
