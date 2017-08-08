using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace DeviantartApi.Requests.Collections
{
    /// <summary>
    /// Fetch collection folders
    /// </summary>
    /// <remarks>
    /// You can preload up to 5 deviations from each folder by passing <c>ExtPreload</c> parameter. It is mainly useful to reduce number of requests to API.
    /// </remarks>
    public class FoldersRequest : PageableRequest<Objects.ArrayOfResults<Objects.SubObjects.Profile.CollectionFolder>>
    {
        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        /// <summary>
        /// The user to list folders for, if omitted the authenticated user is used
        /// </summary>
        [Parameter("username")]
        public string Username { get; set; }

        /// <summary>
        /// The option to include the content count per each collection folder
        /// </summary>
        [Parameter("calculate_size")]
        public bool? CalculateSize { get; set; }

        /// <summary>
        /// Include first 5 deviations from the folder
        /// </summary>
        [Parameter("ext_preload")]
        public bool? ExtPreload { get; set; }

        public override Task<Response<Objects.ArrayOfResults<Objects.SubObjects.Profile.CollectionFolder>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => MatureContent);
            values.AddParameter(() => Username);
            values.AddParameter(() => CalculateSize);
            values.AddParameter(() => ExtPreload);
            values.AddParameter(() => Offset);
            values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync("collections/folders?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
