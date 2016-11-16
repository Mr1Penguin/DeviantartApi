using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash.Publish
{
    using System.Threading;

    public class CategoryTreeRequest : Request<Objects.CategoryTree>
    {
        [Parameter("catpath")]
        public string CatPath { get; set; }

        [Parameter("filetype")]
        public string FileType { get; set; }

        [Parameter("frequent")]
        public bool Frequent { get; set; }

        public override async Task<Response<Objects.CategoryTree>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => CatPath);
            values.AddParameter(() => FileType);
            values.AddParameter(() => Frequent);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"stash/publish/categorytree?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
