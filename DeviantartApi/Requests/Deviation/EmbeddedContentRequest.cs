using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Deviation
{
    public class EmbeddedContentRequest : PageableRequest<Objects.ArrayOfResults<Objects.Deviation>>
    {
        public enum Error
        {
            DeviatonNotFound = 0,
            UnsupportedDeviationType = 1
        }

        [Parameter("deviationid")]
        public string DeviationId { get; set; }

        [Parameter("offset_deviationid")]
        public string OffsetDeviationId { get; set; }

        public EmbeddedContentRequest(string deviationId)
        {
            DeviationId = deviationId;
        }

        public override Task<Response<Objects.ArrayOfResults<Objects.Deviation>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => DeviationId);
            values.AddParameter(() => OffsetDeviationId);
            values.AddParameter(() => Offset);
            values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"deviation/embeddedcontent?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
