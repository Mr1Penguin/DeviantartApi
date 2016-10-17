using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse
{
    public class CategorytreeRequest : Request<Objects.CategoryTree>
    {
        /// <summary>
        /// Default path: "/"
        /// </summary>
        [Parameter("catpath")]
        public string Catpath { get; set; } = "/";

        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        public override async Task<Response<Objects.CategoryTree>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => Catpath);
            values.AddParameter(() => MatureContent);
            return await ExecuteDefaultGetAsync("browse/categorytree?" + values.ToGetParameters());
        }
    }
}
