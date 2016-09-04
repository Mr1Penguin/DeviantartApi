using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse.Tags
{
    public class SearchRequest : Request<Objects.ArrayOfResults<Objects.SubObjects.TagNameItem>>
    {
        public string Tag { get; set; }

        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.TagNameItem>>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync("browse/tags/search?" + $"tag_name={Tag}");
        }
    }
}
