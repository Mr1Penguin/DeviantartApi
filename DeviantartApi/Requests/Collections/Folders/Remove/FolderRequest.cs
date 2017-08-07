using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Collections.Folders.Remove
{
    public class FolderRequest : Request<Objects.PostResponse>
    {
        //todo: rename Path to Type
        protected virtual string FolderPath { get; set; } = "collections";

        /// <summary>
        /// The UUID of the folder to delete
        /// </summary>
        public string FolderId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderRequest"/> class.
        /// </summary>
        /// <param name="folderId">The UUID of the folder to delete</param>
        public FolderRequest(string folderId)
        {
            FolderId = folderId;
        }

        public override Task<Response<Objects.PostResponse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"{FolderPath}/folders/remove/{FolderId}?", cancellationToken);
        }
    }
}
