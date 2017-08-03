using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Collections.Folders
{
    /// <summary>
    /// Create new collection folder.
    /// </summary>
    /// <remarks>
    /// Only <c>Name</c> and <c>FolderId</c> used in response object of <see cref="CollectionFolder"/> type.
    /// </remarks>
    public class CreateRequest : Request<Objects.SubObjects.Profile.CollectionFolder>
    {
        [Parameter("folder")]
        public string FolderName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRequest"/> class.
        /// </summary>
        /// <param name="folderName">The name of the folder to create</param>
        public CreateRequest(string folderName)
        {
            FolderName = folderName;
        }

        public override Task<Response<Objects.SubObjects.Profile.CollectionFolder>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => FolderName);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultPostAsync("collections/folders/create", values, cancellationToken);
        }
    }
}
