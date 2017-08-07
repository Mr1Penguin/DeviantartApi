using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes.Folders
{
    public class RemoveRequest : Collections.Folders.Remove.FolderRequest
    {
        protected override string FolderPath => "notes";

        public RemoveRequest(string folderId) : base(folderId)
        {
        }

        public override Task<Response<Objects.PostResponse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultPostAsync($"{FolderPath}/folders/remove/{FolderId}?", null, cancellationToken);
        }
    }
}
