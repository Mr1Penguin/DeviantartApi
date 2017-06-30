using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Feed
{
    using System.Threading;

    /// <summary>
    /// Fetch Watch Feed 
    /// <para>GET https://www.deviantart.com/api/v1/oauth2/feed/home </para>
    /// <para>Required scopes: feed</para>
    /// </summary>
    public class HomeRequest : PageableRequest<Objects.ArrayOfItems<Objects.SubObjects.FeedItem>>
    {
        /// <summary>
        /// Include mature content?
        /// </summary>
        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        public override Task<Response<Objects.ArrayOfItems<Objects.SubObjects.FeedItem>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => MatureContent);
            values.AddParameter(() => Cursor);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync("feed/home?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
