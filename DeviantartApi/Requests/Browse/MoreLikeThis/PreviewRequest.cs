using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse.MoreLikeThis
{
    /// <summary>
    /// Fetch More Like This preview result for a seed deviation.
    /// </summary>
    public class PreviewRequest : Request<Objects.MltPreview>
    {
        /// <summary>
        /// Request's specific error list.
        /// </summary>
        public enum ErrorCode
        {
            /// <summary>
            /// Invalid Seed Requested.
            /// </summary>
            InvalidSeedRequested = 0
        }

        /// <summary>
        /// Expansions for request.
        /// </summary>
        /// <remarks>
        /// To specify multiple expansion options, separate each option with a comma.
        /// Note: Using expansion options counts as 1 extra request per option toward your clients rate limit.
        /// </remarks>
        public enum UserExpand
        {
            /// <summary>
            /// Add <c>IsWatching</c> flag to author in response.
            /// </summary>
            Watch
        }

        /// <summary>
        /// Expansions for <see cref="Objects.User"/> object.
        /// </summary>
        [Parameter("user")]
        [Expands]
        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();

        /// <summary>
        /// The deviationid to fetch more like.
        /// </summary>
        [Parameter("seed")]
        public string Seed { get; set; }

        /// <summary>
        /// Get response with mature content.
        /// </summary>
        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PreviewRequest"/> class.
        /// </summary>
        /// <param name="seed">The deviationid to fetch more like.</param>
        public PreviewRequest(string seed)
        {
            Seed = seed;
        }

        /// <summary>
        /// Execute request async.
        /// </summary>
        /// <param name="cancellationToken">Token for cancellation of request.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains <see cref="Objects.MltPreview"/> wrapped in <see cref="Response{T}"/> struct.
        /// </returns>
        public override Task<Response<Objects.MltPreview>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddHashSetParameter(() => UserExpands);
            values.AddParameter(() => Seed);
            values.AddParameter(() => MatureContent);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync("browse/morelikethis/preview?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
