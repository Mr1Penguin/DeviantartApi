using System.Threading.Tasks;

namespace DeviantartApi.Requests.Deviation
{
    using System.Threading;

    public class DownloadRequest : Request<Objects.Download>
    {
        public enum Error
        {
            DeviatonNotFound = 1,
            DeviationNotDownloadable = 2,
            FileNotFound = 3
        }

        private string deviationid;

        public DownloadRequest(string eviationid)
        {
            deviationid = eviationid;
        }

        public override async Task<Response<Objects.Download>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"deviation/download/{deviationid}?", cancellationToken);
        }
    }
}
