using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Deviation
{
    public class ContentRequest : Request<Objects.Content>
    {
        public enum Error
        {
            DeviatonNotFound = 0,
            UnsupportedDeviationType = 1
        }

        public string DeviationId { get; set; }

        public override async Task<Response<Objects.Content>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"deviation/content?deviationid={DeviationId}");
        }
    }
}
