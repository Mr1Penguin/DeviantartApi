using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes
{
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

        public override async Task<Response<Objects.Note>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"notes/{_noteid}?");
        }
    }
}
