using System.Threading.Tasks;

namespace DeviantartApi.Requests.User.Friends
{
    using System.Threading;

    public class UnwatchRequest : Request<Objects.BaseObject>
    {
        public enum Error
        {
            UserNotFound = 0
        }

        private string _username;

        public UnwatchRequest(string username)
        {
            _username = username;
        }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"user/friends/unwatch/{_username}", cancellationToken);
        }
    }
}
