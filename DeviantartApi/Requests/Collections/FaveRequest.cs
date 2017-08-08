using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Collections
{
    /// <summary>
    /// Add deviation to favourites 
    /// </summary>
    /// <remarks>
    /// You can add deviation to multiple collections at once. If you omit folderid parameter, it will be added to Featured collection.
    /// The favourites field contains total number of times this deviation was favourited after the fave event.
    /// Users can fave their own deviations, when this happens the fave is not counted but the item is added to the requested folder.
    /// </remarks>
    public class FaveRequest : Request<Objects.Fave>
    {
        /// <summary>
        /// Id of the Deviation to favourite
        /// </summary>
        [Parameter("deviationid")]
        public string DeviationId { get; set; }

        /// <summary>
        /// Optional UUID of the Collection folder to add the favourite into
        /// </summary>
        [Parameter("folderid")]
        public HashSet<string> FolderIds { get; set; } = new HashSet<string>();

        public FaveRequest(string deviationId)
        {
            DeviationId = deviationId;
        }

        public override Task<Response<Objects.Fave>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => DeviationId);
            values.AddHashSetParameter(() => FolderIds);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultPostAsync("collections/fave", values, cancellationToken);
        }
    }
}
