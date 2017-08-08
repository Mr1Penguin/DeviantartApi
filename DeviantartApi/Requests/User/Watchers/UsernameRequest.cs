using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User.Watchers
{
    public class UsernameRequest : PageableRequest<Objects.ArrayOfResults<Objects.Watcher>>
    {
        public enum UserExpand
        {
            Details,
            Geo,
            Profile,
            Stats
        }

        public string Username { get; set; }

        [Parameter("user")]
        [Expands]
        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();

        public UsernameRequest(string username)
        {
            Username = username;
        }

        public override Task<Response<Objects.ArrayOfResults<Objects.Watcher>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddHashSetParameter(() => UserExpands);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"user/watchers/{Username}?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
