using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes
{
    public class NoteRequest : Request<Objects.Note>
    {
        public enum Error
        {
            NoteNotFound = 0
        }

        public string NoteId { get; set; }

        public NoteRequest(string noteid)
        {
            NoteId = noteid;
        }

        public override async Task<Response<Objects.Note>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"notes/{NoteId}?", cancellationToken);
        }
    }
}
