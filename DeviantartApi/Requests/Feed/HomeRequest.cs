using System.Threading.Tasks;

namespace DeviantartApi.Requests.Feed
{
    public class HomeRequest : PageableRequest<Objects.ArrayOfItems<Objects.SubObjects.FeedItem>>
    {
        public bool LoadMature { get; set; }

        public override async Task<Response<Objects.ArrayOfItems<Objects.SubObjects.FeedItem>>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync("feed/home?" +
                                                $"&mature_content={LoadMature.ToString().ToLower()}" +
                                                $"&cursor={Cursor}");
        }
    }
}
