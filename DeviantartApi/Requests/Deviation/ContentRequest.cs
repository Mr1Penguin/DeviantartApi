using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Deviation
{
    public class ContentRequest : Request<Objects.Content>
    {
        public enum ErrorCode
        {
            DeviatonNotFound = 0,
            UnsupportedDeviationType = 1
        }

        [Parameter("deviationid")]
        public string DeviationId { get; set; }

        public ContentRequest(string deviationId)
        {
            DeviationId = deviationId;
        }

        public override Task<Response<Objects.Content>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => DeviationId);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"deviation/content?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
