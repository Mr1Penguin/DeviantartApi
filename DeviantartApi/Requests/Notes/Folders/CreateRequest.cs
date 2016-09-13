using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes.Folders
{
    public class CreateRequest : Request<Objects.BaseObject>
    {
        public string Title { get; set; }
        public string ParentId { get; set; }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("title", Title);
            values.Add("parentid", ParentId);
            return await ExecuteDefaultPostAsync("notes/folders/create", values);
        }
    }
}
