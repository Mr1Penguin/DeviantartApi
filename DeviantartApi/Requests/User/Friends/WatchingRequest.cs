using System.Threading.Tasks;

namespace DeviantartApi.Requests.User.Friends
{
    using System.Threading;

    public class WatchingRequest : Request<Objects.WatchingResponse>
    {
        public enum Error
        {
            UserNotFound = 0
        }

        private string _username;

        public WatchingRequest(string username)
        {
            _username = username;
        }

        public override async Task<Response<Objects.WatchingResponse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"user/friends/watching/{_username}", cancellationToken);
        }
    }
}
