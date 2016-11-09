using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash.Publish
{
    public class UserDataRequest : Request<Objects.UserData>
    {
        public override async Task<Response<Objects.UserData>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"stash/publish/userdata?");
        }
    }
}
