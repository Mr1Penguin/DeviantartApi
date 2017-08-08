using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User.Friends.Unwatch
{
    public class UsernameRequest : Request<Objects.PostResponse>
    {
        public enum ErrorCode
        {
            UserNotFound = 0
        }

        public string Username { get; set; }

        public UsernameRequest(string username)
        {
            Username = username;
        }

        public override Task<Response<Objects.PostResponse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"user/friends/unwatch/{Username}?", cancellationToken);
        }
    }
}
