using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes
{
    public class FoldersRequests : Request<Objects.ArrayOfResults<Objects.NotesFolder>>
    {
        public override async Task<Response<Objects.ArrayOfResults<Objects.NotesFolder>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"notes/folders?", cancellationToken);
        }
    }
}
