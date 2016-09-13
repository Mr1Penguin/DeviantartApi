using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes.Remove
{
    public class FolderRequest : Request<Objects.BaseObject>
    {
        private string _folderid;

        public FolderRequest(string folderid)
        {
            _folderid = folderid;
        }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            return await ExecuteDefaultPostAsync("notes/remove/{_folderid}", values);
        }
    }
}
