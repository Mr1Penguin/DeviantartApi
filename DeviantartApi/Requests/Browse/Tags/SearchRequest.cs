using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse.Tags
{
    /// <summary>
    /// Autocomplete tags.
    /// </summary>
    public class SearchRequest : Request<Objects.ArrayOfResults<Objects.TagNameItem>>
    {
        /// <summary>
        /// Partial tag name to get autocomplete suggestions for.
        /// </summary>
        [Parameter("tag_name")]
        public string Tag { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchRequest"/> class.
        /// </summary>
        /// <param name="tag">Partial tag name to get autocomplete suggestions for.</param>
        public SearchRequest(string tag)
        {
            Tag = tag;
        }

        /// <summary>
        /// Execute request async.
        /// </summary>
        /// <param name="cancellationToken">Token for cancellation of request.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains <see cref="Objects.ArrayOfResults{T}"/> of <see cref="Objects.TagNameItem"/> wrapped in <see cref="Response{T}"/> struct.
        /// </returns>
        public override async Task<Response<Objects.ArrayOfResults<Objects.TagNameItem>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => Tag);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync("browse/tags/search?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
