using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes.Folders
{
    using System.Threading;

    public class ListRequest : Request<Objects.ArrayOfResults<Objects.SubObjects.NotesFolder>>
    {
        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.NotesFolder>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"notes/folders?", cancellationToken);
        }
    }
}
