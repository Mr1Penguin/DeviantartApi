using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Deviation.Download
{
    public class DeviationRequest : Request<Objects.Download>
    {
        public enum Error
        {
            DeviatonNotFound = 1,
            DeviationNotDownloadable = 2,
            FileNotFound = 3
        }

        private string deviationid;

        public DeviationRequest(string eviationid)
        {
            deviationid = eviationid;
        }

        public override async Task<Response<Objects.Download>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"deviation/download/{deviationid}?");
        }
    }
}
