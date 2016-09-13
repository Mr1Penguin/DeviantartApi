using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes
{
    public class MoveRequest : Request<Objects.BaseObject>
    {
        public HashSet<string> NotesIds { get; set; } = new HashSet<string>();
        public string FolderId { get; set; }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            ulong i;
            i = 0;
            foreach(var val in NotesIds)
                values.Add($"notesids[{i++}]", val);
            values.Add("folderid", FolderId);
            return await ExecuteDefaultPostAsync("notes/move", values);
        }
    }
}
