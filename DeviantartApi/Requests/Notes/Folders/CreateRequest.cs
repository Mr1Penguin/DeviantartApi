using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes.Folders
{
    public class CreateRequest : Request<Objects.NotesFolder>
    {
        [Parameter("title")]
        public string Title { get; set; }

        [Parameter("parentid")]
        public string ParentId { get; set; }

        public CreateRequest(string title)
        {
            Title = title;
        }

        public override Task<Response<Objects.NotesFolder>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => Title);
            values.AddParameter(() => ParentId);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultPostAsync("notes/folders/create", values, cancellationToken);
        }
    }
}
