using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Deviation
{
    public class MetadataRequest : Request<Objects.DeviationMetadata>
    {
        public enum Error
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
        public HashSet<string> DeviationIds { get; set; } = new HashSet<string>();

        public override async Task<Response<Objects.DeviationMetadata>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => ExtSubmission);
            values.AddParameter(() => ExtCamera);
            values.AddParameter(() => ExtStats);
            values.AddParameter(() => ExtCollection);
            values.AddHashSetParameter(() => DeviationIds);
            return await ExecuteDefaultGetAsync("deviation/metadata?" + values.ToGetParameters());
        }
    }
}
