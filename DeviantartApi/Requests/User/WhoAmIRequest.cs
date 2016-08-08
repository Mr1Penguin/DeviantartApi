using System;
using System.Collections.Generic;
using System.Linq;
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

        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();

        public override async Task<Response<Objects.User>> ExecuteAsync()
        {
            return await ExecuteDefaultAsync("user/whoami?" + "expand=" +
                                             string.Join(",", UserExpands.Select(x => "user." + x.ToString().ToLower()).ToList()));
        }
    }
}
