using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User.Friends
{
    public class UsernameRequest : PageableRequest<Objects.ArrayOfResults<Objects.Friend>>
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

        public override async Task<Response<Objects.ArrayOfResults<Objects.Friend>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddHashSetParameter(() => UserExpands);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"user/friends/{Username}?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
