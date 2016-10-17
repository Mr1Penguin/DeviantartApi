using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes
{
    public class MarkRequest : Request<Objects.BaseObject>
    {
        [Parameter("notesids")]
        public HashSet<string> NotesIds { get; set; } = new HashSet<string>();

        [Parameter("mark_as")]
        public string MarkAs { get; set; }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddHashSetParameter(() => NotesIds);
            values.AddParameter(() => MarkAs);
            return await ExecuteDefaultPostAsync("notes/mark", values);
        }
    }
}
