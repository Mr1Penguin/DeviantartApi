using System;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Feed
{
    public class HomeRequest : PageableRequest<Objects.Feed>
    {
        public bool LoadMature { get; set; }

        public override async Task<Response<Objects.Feed>> ExecuteAsync()
        {
            return await ExecuteDefaultAsync("feed/home?" +
                                             $"&mature_content={LoadMature.ToString().ToLower()}" +
                                             $"&cursor={Cursor}");
        }
    }
}
