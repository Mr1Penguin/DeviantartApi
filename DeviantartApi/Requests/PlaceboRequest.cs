using System.Threading.Tasks;
using DeviantartApi.Objects;

namespace DeviantartApi.Requests
{

    public class PlaceboRequest : Request<PlaceboStatus>
    {

        public override async Task<Response<PlaceboStatus>> ExecuteAsync()
        {
            return
                new Response<PlaceboStatus>(
                    await
                        Requester.MakeRequestAsync<PlaceboStatus>("https://www.deviantart.com/api/v1/oauth2/placebo?" +
                                                                  $"access_token={Requester.AccessToken}"));
        }
    }
}
