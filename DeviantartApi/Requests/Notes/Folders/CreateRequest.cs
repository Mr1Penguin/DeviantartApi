using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes.Folders
{
    public class CreateRequest : Request<Objects.BaseObject>
    {
        [Parameter("title")]
        public string Title { get; set; }

        [Parameter("parentid")]
        public string ParentId { get; set; }

        public CreateRequest(string title)
        {
            Title = title;
        }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => Title);
            values.AddParameter(() => ParentId);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultPostAsync("notes/folders/create", values, cancellationToken);
        }
    }
}
