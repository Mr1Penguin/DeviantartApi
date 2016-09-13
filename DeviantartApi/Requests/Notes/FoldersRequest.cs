using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes
{
    public class FoldersRequest : Request<Objects.ArrayOfResults<Objects.SubObjects.NotesFolder>>
    {
        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.NotesFolder>>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"notes/folders?");
        }
    }
}
