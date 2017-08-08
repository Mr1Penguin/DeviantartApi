using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse
{
    /// <summary>
    /// Browse undiscovered deviations
    /// </summary>
    public class UndiscoveredRequest : BrowseRequest
    {
        public override Task<Response<Objects.Browse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => CategoryPath);
            values.AddParameter(() => Offset);
            values.AddParameter(() => Limit);
            values.AddHashSetParameter(() => UserExpands);
            values.AddParameter(() => MatureContent);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync("browse/undiscovered?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
