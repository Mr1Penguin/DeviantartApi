using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Data
{
    public class CountriesRequest : Request<Objects.Countries>
    {
        public override async Task<Response<Objects.Countries>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"data/countries?");
        }
    }
}
