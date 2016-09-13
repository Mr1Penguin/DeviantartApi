using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes.Rename
{
    public class FolderRequest : Request<Objects.BaseObject>
    {
        public string Title { get; set; }

        private string _folderid;

        public FolderRequest(string folderid)
        {
            _folderid = folderid;
        }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("title", Title);
            return await ExecuteDefaultPostAsync("notes/rename/{_folderid}", values);
        }
    }
}
