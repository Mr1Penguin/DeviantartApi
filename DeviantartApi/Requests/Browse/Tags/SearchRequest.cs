using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse.Tags
{
    public class SearchRequest : Request<Objects.TagsSearchResults>
    {
        public string Tag { get; set; }

        public override async Task<Response<Objects.TagsSearchResults>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync("browse/tags/search?" + $"tag_name={Tag}");
        }
    }
}
