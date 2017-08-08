using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes.Folders
{
    public class RenameRequest : Request<Objects.BaseObject>
    {
        [Parameter("title")]
        public string Title { get; set; }

        public string FolderId { get; set; }

        public RenameRequest(string folderid, string title)
        {
            FolderId = folderid;
            Title = title;
        }

        public override Task<Response<Objects.BaseObject>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => Title);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultPostAsync($"notes/folders/rename/{FolderId}", values, cancellationToken);
        }
    }
}
