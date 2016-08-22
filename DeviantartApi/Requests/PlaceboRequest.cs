using DeviantartApi.Objects;
using System.Threading.Tasks;

namespace DeviantartApi.Requests
{
    public class PlaceboRequest : Request<PlaceboStatus>
    {
        public override async Task<Response<PlaceboStatus>> ExecuteAsync()
        {
            return
                new Response<PlaceboStatus>(
                    await
                        Requester.MakeRequestAsync<PlaceboStatus>("placebo?" +
                                                                  $"access_token={Requester.AccessToken}"));
        }
    }
}
