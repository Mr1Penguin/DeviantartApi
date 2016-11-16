using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes
{
    using System.Threading;

    public class NoteRequest : Request<Objects.Note>
    {
        public enum Error
        {
            NoteNotFound = 0
        }

        private string _noteid;

        public NoteRequest(string noteid)
        {
            _noteid = noteid;
        }

        public override async Task<Response<Objects.Note>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"notes/{_noteid}?", cancellationToken);
        }
    }
}
