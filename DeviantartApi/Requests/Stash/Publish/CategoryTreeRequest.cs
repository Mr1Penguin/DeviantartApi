using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash.Publish
{
    public class CategoryTreeRequest : Request<Objects.CategoryTree>
    {
        [Parameter("catpath")]
        public string CatPath { get; set; }

        [Parameter("filetype")]
        public string FileType { get; set; }

        [Parameter("frequent")]
        public bool Frequent { get; set; }

        public override async Task<Response<Objects.CategoryTree>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => CatPath);
            values.AddParameter(() => FileType);
            values.AddParameter(() => Frequent);
            return await ExecuteDefaultGetAsync($"stash/publish/categorytree?" + values.ToGetParameters());
        }
    }
}
