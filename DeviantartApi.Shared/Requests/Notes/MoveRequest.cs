using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes
{
    using System.Threading;

    public class MoveRequest : Request<Objects.BaseObject>
    {
        [Parameter("notesids")]
        public HashSet<string> NotesIds { get; set; } = new HashSet<string>();

        [Parameter("folderid")]
        public string FolderId { get; set; }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddHashSetParameter(() => NotesIds);
            values.AddParameter(() => FolderId);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultPostAsync("notes/move", values, cancellationToken);
        }
    }
}
