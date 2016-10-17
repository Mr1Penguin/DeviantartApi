using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Gallery
{
    public class FoldersRequest : PageableRequest<Objects.ArrayOfResults<Objects.SubObjects.GalleryFolder>>
    {
        [Parameter("username")]
        public string Username { get; set; }

        [Parameter("calculate_size")]
        public bool CalculateSize { get; set; }

        [Parameter("ext_preload")]
        public bool ExtPreload { get; set; }

        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.GalleryFolder>>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => Username);
            values.AddParameter(() => CalculateSize);
            values.AddParameter(() => ExtPreload);
            values.AddParameter(() => MatureContent);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            return await ExecuteDefaultGetAsync($"gallery/folders?" + values.ToGetParameters());
        }
    }
}
