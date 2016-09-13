using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes
{
    public class DeleteRequest : Request<Objects.BaseObject>
    {
        public HashSet<string> NotesIds { get; set; } = new HashSet<string>();

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            ulong i;
            i = 0;
            foreach(var val in NotesIds)
                values.Add($"notesids[{i++}]", val);
            return await ExecuteDefaultPostAsync("notes/delete", values);
        }
    }
}
