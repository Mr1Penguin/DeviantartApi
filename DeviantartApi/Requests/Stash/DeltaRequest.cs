using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash
{
    public class DeltaRequest : PageableRequest<Objects.StashDelta>
    {
        [Parameter("ext_submission")]
        public bool ExtSubmission { get; set; }

        [Parameter("ext_camera")]
        public bool ExtCamera { get; set; }

        [Parameter("ext_stats")]
        public bool ExtStats { get; set; }

        public override async Task<Response<Objects.StashDelta>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => ExtSubmission);
            values.AddParameter(() => ExtCamera);
            values.AddParameter(() => ExtStats);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            if (Cursor != null) values.AddParameter(() => Cursor);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"stash/delta?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
