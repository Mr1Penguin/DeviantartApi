using System.Threading.Tasks;

namespace DeviantartApi.Requests.Data
{
    public class SubmissionRequest : Request<Objects.Information>
    {
        public override async Task<Response<Objects.Information>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"data/submission?");
        }
    }
}
