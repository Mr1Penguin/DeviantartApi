using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User
{
    public class WhoAmIRequest : Request<Objects.User>
    {
        public enum UserExpand
        {
            Details,
            Geo,
            Profile,
            Stats
        }

        [Parameter("user")]
        [Expands]
        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();

        public override async Task<Response<Objects.User>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddHashSetParameter(() => UserExpands);
            return await ExecuteDefaultGetAsync("user/whoami?" + values.ToGetParameters());
        }
    }
}
