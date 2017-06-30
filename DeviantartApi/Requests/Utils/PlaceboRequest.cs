using DeviantartApi.Objects;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace DeviantartApi.Requests.Utils
{
    /// <summary>
    /// Placebo call to confirm your access_token is valid 
    /// </summary>
    public class PlaceboRequest : Request<PlaceboStatus>
    {
        public override async Task<Response<PlaceboStatus>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            PlaceboStatus httpResponse;
            try
            {
                httpResponse = await Requester.MakeRequestAsync<PlaceboStatus>(new Uri(BasePath, $"placebo?access_token={Requester.AccessToken}"), cancellationToken: cancellationToken);
            }
            catch (Exception e)
            {
                httpResponse = new PlaceboStatus
                {
                    Error = "Network error",
                    ErrorDescription = e.Message
                };
            }
            return new Response<PlaceboStatus>(httpResponse);
        }
    }
}
