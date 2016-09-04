using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Gallery
{
    public class AllRequest : PageableRequest<Objects.ArrayOfResults<Objects.Deviation>>
    {
        public string Username { get; set; }

        public override async Task<Response<Objects.ArrayOfResults<Objects.Deviation>>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"gallery/all?"
                + $"username={Username}"
                + (Offset != null ? $"&offset={Offset}" : "") + (Limit != null ? $"&limit={Limit}" : ""));
        }
    }
}
