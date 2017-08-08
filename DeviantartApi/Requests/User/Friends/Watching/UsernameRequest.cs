using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User.Friends.Watching
{
    public class UsernameRequest : Request<Objects.WatchingResponse>
    {
        public enum Error
        {
            UserNotFound = 0
        }

        public string Username { get; set; }

        public UsernameRequest(string username)
        {
            Username = username;
        }

        public override async Task<Response<Objects.WatchingResponse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"user/friends/watching/{Username}?", cancellationToken);
        }
    }
}
