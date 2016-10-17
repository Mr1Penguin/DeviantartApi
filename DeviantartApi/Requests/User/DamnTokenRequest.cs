using System.Threading.Tasks;

namespace DeviantartApi.Requests.User
{
    internal class DamnTokenRequest : Request<Objects.DamnResponse>
    {
        public override async Task<Response<Objects.DamnResponse>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync("user/damntoken");
        }
    }
}
