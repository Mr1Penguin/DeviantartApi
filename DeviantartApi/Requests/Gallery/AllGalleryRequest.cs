using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Gallery
{
    public class AllGalleryRequest : PageableRequest<Objects.Deviations>
    {
        public string Username { get; set; }

        public override async Task<Response<Objects.Deviations>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"gallery/all?"
                + $"username={Username}"
                + (Offset != null ? $"&offset={Offset}" : "") + (Limit != null ? $"&limit={Limit}" : ""));
        }
    }
}
