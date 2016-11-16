using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes.Folders
{
    using System.Threading;

    public class RenameRequest : Request<Objects.BaseObject>
    {
        [Parameter("title")]
        public string Title { get; set; }

        private string _folderid;

        public RenameRequest(string folderid)
        {
            _folderid = folderid;
        }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => Title);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultPostAsync($"notes/rename/{_folderid}", values, cancellationToken);
        }
    }
}
