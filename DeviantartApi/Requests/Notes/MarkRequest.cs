using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes
{
    public class MarkRequest : Request<Objects.BaseObject>
    {
        public enum Mark
        {
            Read,
            Unread,
            Starred,
            NotStarred,
            Spam
        }

        [Parameter("notesids")]
        public HashSet<string> NotesIds { get; set; }

        [Parameter("mark_as")]
        public Mark MarkAs { get; set; }

        public MarkRequest(IEnumerable<string> notesIds, Mark markAs)
        {
            NotesIds = new HashSet<string>(notesIds);
            MarkAs = markAs;
        }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddHashSetParameter(() => NotesIds);
            values.AddParameter(() => MarkAs);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultPostAsync("notes/mark", values, cancellationToken);
        }
    }
}
