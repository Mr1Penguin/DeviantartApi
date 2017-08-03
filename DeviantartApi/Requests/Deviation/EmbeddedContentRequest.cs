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

        public override async Task<Response<Objects.ArrayOfResults<Objects.Deviation>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => DeviationId);
            values.AddParameter(() => OffsetDeviationId);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"deviation/embeddedcontent?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
