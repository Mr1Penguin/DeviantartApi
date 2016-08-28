using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Deviation
{
    public class EmbeddedContentRequest : PageableRequest<Objects.Deviations>
    {
        public enum Error
        {
            DeviatonNotFound = 0,
            UnsupportedDeviationType = 1
        }

        public string DeviationId { get; set; }
        public string OffsetDeviationId { get; set; }

        public override async Task<Response<Objects.Deviations>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"deviation/embeddedcontent?deviationid={DeviationId}&offset_deviationid={OffsetDeviationId}"
                + (Offset != null ? $"&offset={Offset}" : "") + (Limit != null ? $"&limit={Limit}" : ""));
        }
    }
}
