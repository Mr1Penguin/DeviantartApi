using DeviantartApi.Objects;
using System.Threading.Tasks;

namespace DeviantartApi.Requests
{
    using System.Threading;

    /// <summary>
    /// Placebo call to confirm your access_token is valid 
    /// </summary>
    public class PlaceboRequest : Request<PlaceboStatus>
    {
        public override async Task<Response<PlaceboStatus>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var httpResponse = await Requester.MakeRequestAsync<PlaceboStatus>("placebo?" + $"access_token={Requester.AccessToken}", cancellationToken);
            return new Response<PlaceboStatus>(httpResponse);
        }
    }
}
