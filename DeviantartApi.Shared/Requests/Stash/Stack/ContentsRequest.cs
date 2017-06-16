using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash
{
    using System.Threading;

    internal class ContentsRequest : PageableRequest<Objects.ArrayOfResults<Objects.StashMetadata>>
    {
        public enum Error
        {
            StackNotFound = 0
        }

        [Parameter("ext_submission")]
        public bool ExtSubmission { get; set; }

        [Parameter("ext_camera")]
        public bool ExtCamera { get; set; }

        [Parameter("ext_stats")]
        public bool ExtStats { get; set; }

        private string _stackId;

        public ContentsRequest(string stackId)
        {
            _stackId = stackId;
        }

        public override async Task<Response<Objects.ArrayOfResults<Objects.StashMetadata>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => ExtSubmission);
            values.AddParameter(() => ExtCamera);
            values.AddParameter(() => ExtStats);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"stash/{_stackId}/contents?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
