using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests
{
    public class NotesRequest : PageableRequest<Objects.ArrayOfResults<Objects.Note>>
    {
        public string FolderId { get; set; }

        public override async Task<Response<Objects.ArrayOfResults<Objects.Note>>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"notes?"
                + $"folderid={FolderId}"
                + (Offset != null ? $"&offset={Offset}" : "") + (Limit != null ? $"&limit={Limit}" : ""));
        }
    }
}
