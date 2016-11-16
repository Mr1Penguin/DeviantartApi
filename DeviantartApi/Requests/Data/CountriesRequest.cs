using System.Threading.Tasks;

namespace DeviantartApi.Requests.Data
{
    using System.Threading;

    public class CountriesRequest : Request<Objects.ArrayOfResults<Objects.SubObjects.Country>>
    {
        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.Country>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"data/countries?", cancellationToken);
        }
    }
}
