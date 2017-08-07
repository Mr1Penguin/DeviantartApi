using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes
{
    public class DeleteRequest : Request<Objects.BaseObject>
    {
        [Parameter("notesids")]
        public HashSet<string> NotesIds { get; set; } = new HashSet<string>();

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddHashSetParameter(() => NotesIds);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultPostAsync("notes/delete", values, cancellationToken);
        }
    }
}
