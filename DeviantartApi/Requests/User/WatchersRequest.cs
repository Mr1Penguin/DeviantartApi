using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User
{
    public class WatchersRequest : PageableRequest<Objects.ArrayOfResults<Objects.SubObjects.Watcher>>
    {
        public enum UserExpand
        {
            Details,
            Geo,
            Profile,
            Stats
        }

        private string _username;

        [Parameter("user")]
        [Expands]
        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();

        public WatchersRequest(string username)
        {
            _username = username;
        }

        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.Watcher>>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddHashSetParameter(() => UserExpands);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            return await ExecuteDefaultGetAsync($"/user/watchers/{_username}?" + values.ToGetParameters());
        }
    }
}
