using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes
{
    public class SendRequest : Request<Objects.BaseObject>
    {
        public HashSet<string> To { get; set; } = new HashSet<string>();
        public string Subject { get; set; }
        public string Body { get; set; }
        public string NoteId { get; set; }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            ulong i;
            i = 0;
            foreach(var val in To)
                values.Add($"to[{i++}]", val);
            values.Add("subject", Subject);
            values.Add("body", Body);
            values.Add("noteid", NoteId);
            return await ExecuteDefaultPostAsync("notes/send", values);
        }
    }
}
