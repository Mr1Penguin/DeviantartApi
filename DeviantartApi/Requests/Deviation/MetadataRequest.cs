using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Deviation
{
    public class MetadataRequest : Request<Objects.DeviationMetadata>
    {
        public enum ErrorCode
        {
            RequestedTooManyDeviations = 0
        }

        [Parameter("ext_submission")]
        public bool ExtSubmission { get; set; }

        [Parameter("ext_camera")]
        public bool ExtCamera { get; set; }

        [Parameter("ext_stats")]
        public bool ExtStats { get; set; }

        [Parameter("ext_collection")]
        public bool ExtCollection { get; set; }

        [Parameter("deviationids")]
        public HashSet<string> DeviationIds { get; set; }

        public MetadataRequest(IEnumerable<string> deviationIds)
        {
            DeviationIds = new HashSet<string>(deviationIds);
        }

        public override Task<Response<Objects.DeviationMetadata>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => ExtSubmission);
            values.AddParameter(() => ExtCamera);
            values.AddParameter(() => ExtStats);
            values.AddParameter(() => ExtCollection);
            values.AddHashSetParameter(() => DeviationIds);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync("deviation/metadata?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
