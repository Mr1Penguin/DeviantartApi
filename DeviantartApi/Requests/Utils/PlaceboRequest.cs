using DeviantartApi.Objects;
using System.Threading.Tasks;

namespace DeviantartApi.Requests
{
    /// <summary>
    /// Placebo call to confirm your access_token is valid 
    /// </summary>
    public class PlaceboRequest : Request<PlaceboStatus>
    {
        public override async Task<Response<PlaceboStatus>> ExecuteAsync()
        {
            var httpResponse = await Requester.MakeRequestAsync<PlaceboStatus>("placebo?" + $"access_token={Requester.AccessToken}");
            return new Response<PlaceboStatus>(httpResponse);
        }
    }
}
