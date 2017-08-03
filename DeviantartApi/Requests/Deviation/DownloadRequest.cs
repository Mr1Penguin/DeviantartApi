using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Deviation
{
    public class DownloadRequest : Request<Objects.SubObjects.Deviation.Image>
    {
        public enum Error
        {
            DeviatonNotFound = 1,
            DeviationNotDownloadable = 2,
            FileNotFound = 3
        }

        public string Deviationid { get; set; }

        public DownloadRequest(string deviationId)
        {
            Deviationid = deviationId;
        }

        public override async Task<Response<Objects.SubObjects.Deviation.Image>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"deviation/download/{Deviationid}?", cancellationToken);
        }
    }
}
