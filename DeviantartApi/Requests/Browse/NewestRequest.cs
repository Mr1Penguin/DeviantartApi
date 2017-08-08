using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse
{
    /// <summary>
    /// Browse newest deviations
    /// </summary>
    public class NewestRequest : BrowseRequest
    {
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
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync("browse/newest?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
