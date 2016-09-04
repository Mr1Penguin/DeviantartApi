using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Data
{
    public class CountriesRequest : Request<Objects.ArrayOfResults<Objects.SubObjects.Country>>
    {
        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.Country>>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"data/countries?");
        }
    }
}
