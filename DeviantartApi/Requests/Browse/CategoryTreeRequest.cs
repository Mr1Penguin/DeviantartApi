using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse
{
    /// <summary>
    /// Fetch category information for browsing
    /// </summary>
    public class CategoryTreeRequest : Request<Objects.CategoryTree>
    {
        /// <summary>
        /// The category to list children of. Default path: "/"
        /// </summary>
        [Parameter("catpath")]
        public string Catpath { get; set; } = "/";

        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        public CategoryTreeRequest(string catpath = "/")
        {
            Catpath = catpath;
        }

        public override Task<Response<Objects.CategoryTree>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => Catpath);
            values.AddParameter(() => MatureContent);
            return ExecuteDefaultGetAsync("browse/categorytree?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
