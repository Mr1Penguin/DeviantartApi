using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes.Folders
{
    using System.Threading;

    public class RemoveRequest : Request<Objects.BaseObject>
    {
        private string _folderid;

        public RemoveRequest(string folderid)
        {
            _folderid = folderid;
        }
        
        public override async Task<Response<Objects.BaseObject>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultPostAsync($"notes/remove/{_folderid}", values, cancellationToken);
        }
    }
}
