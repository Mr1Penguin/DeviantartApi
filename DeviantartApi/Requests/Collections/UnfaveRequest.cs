using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Collections
{
    /// <summary>
    /// Remove deviation from favourites
    /// </summary>
    /// <remarks>
    /// You can remove deviation from multiple collections at once. If you omit <c>folderid</c> parameter, it will be removed from Featured collection.
    /// The <c>Favourites</c> field contains total number of times this deviation was favourited after the unfave event.
    /// /// If a user has faved their own deviation, unfave can be used to remove the deviation from a given folder. Favorite counts are not affected if the deviation is owned by the user. 
    /// </remarks>
    public class UnfaveRequest : Request<Objects.Fave>
    {
        /// <summary>
        /// Id of the Deviation to unfavourite
        /// </summary>
        [Parameter("deviationid")]
        public string DeviationId { get; set; }

        /// <summary>
        /// Optional UUID remove from a single collection folder
        /// </summary>
        [Parameter("folderid")]
        public HashSet<string> FolderIds { get; set; } = new HashSet<string>();
        
        public override async Task<Response<Objects.Fave>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => DeviationId);
            values.AddHashSetParameter(() => FolderIds);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultPostAsync("collections/unfave", values, cancellationToken);
        }
    }
}
