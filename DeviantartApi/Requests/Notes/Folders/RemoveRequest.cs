using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes.Folders
{
    public class RemoveRequest : Request<Objects.BaseObject>
    {
        private string _folderid;

        public RemoveRequest(string folderid)
        {
            _folderid = folderid;
        }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            return await ExecuteDefaultPostAsync($"notes/remove/{_folderid}", values);
        }
    }
}
