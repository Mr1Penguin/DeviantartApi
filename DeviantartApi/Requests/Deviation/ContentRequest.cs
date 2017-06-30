using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Deviation
{
    using System.Threading;

    public class ContentRequest : Request<Objects.Content>
    {
        public enum ErrorCode
        {
            DeviatonNotFound = 0,
            UnsupportedDeviationType = 1
        }

        [Parameter("deviationid")]
        public string DeviationId { get; set; }

        public override  Task<Response<Objects.Content>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => DeviationId);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"deviation/content?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
