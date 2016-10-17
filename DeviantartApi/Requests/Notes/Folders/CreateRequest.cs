using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes.Folders
{
    public class CreateRequest : Request<Objects.BaseObject>
    {
        [Parameter("title")]
        public string Title { get; set; }

        [Parameter("parentid")]
        public string ParentId { get; set; }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => Title);
            values.AddParameter(() => ParentId);
            return await ExecuteDefaultPostAsync("notes/folders/create", values);
        }
    }
}
