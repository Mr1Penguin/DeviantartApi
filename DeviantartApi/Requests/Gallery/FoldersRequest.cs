using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Gallery
{
    public class FoldersRequest : PageableRequest<Objects.ArrayOfResults<Objects.SubObjects.GalleryFolder>>
    {
        public string Username { get; set; }
        public bool CalculateSize { get; set; }
        public bool ExtPreload { get; set; }
        public bool MatureContent { get; set; }

        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.GalleryFolder>>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"gallery/folders?"
                + $"username={Username}"
                + "&" + $"calculate_size={CalculateSize.ToString().ToLower()}"
                + "&" + $"ext_preload={ExtPreload.ToString().ToLower()}"
                + "&" + $"mature_content={MatureContent.ToString().ToLower()}"
                + (Offset != null ? $"&offset={Offset}" : "") + (Limit != null ? $"&limit={Limit}" : ""));
        }
    }
}
