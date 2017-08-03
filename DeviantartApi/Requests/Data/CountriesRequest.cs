using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Data
{
    public class CountriesRequest : Request<Objects.ArrayOfResults<Objects.Country>>
    {
        public override async Task<Response<Objects.ArrayOfResults<Objects.Country>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"data/countries?", cancellationToken);
        }
    }
}
