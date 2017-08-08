using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes
{
    public class MoveRequest : Request<Objects.PostResponse>
    {
        [Parameter("notesids")]
        public HashSet<string> NotesIds { get; set; } = new HashSet<string>();

        [Parameter("folderid")]
        public string FolderId { get; set; }

        public MoveRequest(IEnumerable<string> notesIds, string folderId)
        {
            NotesIds = new HashSet<string>(notesIds);
            FolderId = folderId;
        }

        public override Task<Response<Objects.PostResponse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddHashSetParameter(() => NotesIds);
            values.AddParameter(() => FolderId);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultPostAsync("notes/move", values, cancellationToken);
        }
    }
}
