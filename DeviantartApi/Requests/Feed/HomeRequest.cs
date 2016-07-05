using System;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Feed
{
    public class HomeRequest : PageableRequest<Objects.Feed>
    {
        public bool LoadMature { get; set; }

        public override async Task<Response<Objects.Feed>> ExecuteAsync()
        {
            Objects.Feed result;
            try
            {
                await Requester.CheckTokenAsync();
                result = await Requester.MakeRequestAsync<Objects.Feed>("https://www.deviantart.com/api/v1/oauth2/feed/home?" +
                                                                        $"access_token={Requester.AccessToken}" +
                                                                        $"&mature_content={LoadMature}" +
                                                                        $"&cursor={Cursor}");
            }
            catch (Exception e)
            {
                return new Response<Objects.Feed>(true, e.Message);
            }
            return new Response<Objects.Feed>(result);
        }
    }
}
