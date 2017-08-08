using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace DeviantartApi.Requests.Gallery
{
    public class FoldersRequest : PageableRequest<Objects.ArrayOfResults<Objects.SubObjects.Profile.GalleryFolder>>
    {
        [Parameter("username")]
        public string Username { get; set; }

        [Parameter("calculate_size")]
        public bool? CalculateSize { get; set; }

        [Parameter("ext_preload")]
        public bool? ExtPreload { get; set; }

        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        public override Task<Response<Objects.ArrayOfResults<Objects.SubObjects.Profile.GalleryFolder>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => Username);
            values.AddParameter(() => CalculateSize);
            values.AddParameter(() => ExtPreload);
            values.AddParameter(() => MatureContent);
            values.AddParameter(() => Offset);
            values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"gallery/folders?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
