using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash
{
    public class DeltaRequest : PageableRequest<Objects.StashDelta>
    {
        public bool ExtSubmission { get; set; }
        public bool ExtCamera { get; set; }
        public bool ExtStats { get; set; }

        public override async Task<Response<Objects.StashDelta>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"stash/delta?"
                + $"ext_submission={ExtSubmission.ToString().ToLower()}"
                + "&" + $"ext_camera={ExtCamera.ToString().ToLower()}"
                + "&" + $"ext_stats={ExtStats.ToString().ToLower()}"
                + (Offset != null ? $"&offset={Offset}" : "") + (Limit != null ? $"&limit={Limit}" : "") + (Cursor != null ? $"&cursor={Cursor}" : ""));
        }
    }
}
