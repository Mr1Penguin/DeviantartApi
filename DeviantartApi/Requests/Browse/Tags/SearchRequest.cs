using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse.Tags
{
    /// <summary>
    /// Autocomplete tags 
    /// </summary>
    public class SearchRequest : Request<Objects.ArrayOfResults<Objects.TagNameItem>>
    {
        /// <summary>
        /// Partial tag name to get autocomplete suggestions for
        /// </summary>
        [Parameter("tag_name")]
        public string Tag { get; set; }

        public override async Task<Response<Objects.ArrayOfResults<Objects.TagNameItem>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => Tag);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync("browse/tags/search?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
