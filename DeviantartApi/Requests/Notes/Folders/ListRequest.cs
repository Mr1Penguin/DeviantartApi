using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes.Folders
{
    public class ListRequest : Request<Objects.ArrayOfResults<Objects.SubObjects.NotesFolder>>
    {
        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.NotesFolder>>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"notes/folders?");
        }
    }
}
