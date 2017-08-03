using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Collections.Folders.Remove
{
    public class FolderRequest : Request<Objects.BaseObject>
    {
        /// <summary>
        /// The UUID of the folder to delete
        /// </summary>
        [Parameter("folderid")]
        public string FolderId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderRequest"/> class.
        /// </summary>
        /// <param name="folderId">The UUID of the folder to delete</param>
        public FolderRequest(string folderId)
        {
            FolderId = folderId;
        }

        public override Task<Response<Objects.BaseObject>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultPostAsync($"collections/folders/remove/{FolderId}", values, cancellationToken);
        }
    }
}
