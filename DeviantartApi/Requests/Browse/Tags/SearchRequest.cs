using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse.Tags
{
    public class SearchRequest : Request<Objects.ArrayOfResults<Objects.SubObjects.TagNameItem>>
    {
        [Parameter("tag_name")]
        public string Tag { get; set; }

        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.TagNameItem>>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => Tag);
            return await ExecuteDefaultGetAsync("browse/tags/search?" + values.ToGetParameters());
        }
    }
}
