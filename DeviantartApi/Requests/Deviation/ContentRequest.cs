using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Deviation
{
    using System.Threading;

    public class ContentRequest : Request<Objects.Content>
    {
        public enum Error
        {
            DeviatonNotFound = 0,
            UnsupportedDeviationType = 1
        }

        [Parameter("deviationid")]
        public string DeviationId { get; set; }

        public override async Task<Response<Objects.Content>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => DeviationId);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"deviation/content?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
