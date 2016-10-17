using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User
{
    public class WhoIsRequest : Request<Objects.ArrayOfResults<Objects.User>>
    {
        public enum Error
        {
            TooManyUserRequested,
            UnknownUser
        }

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

        [Parameter("usernames")]
        public HashSet<string> Usernames { get; set; } = new HashSet<string>();

        public override async Task<Response<Objects.ArrayOfResults<Objects.User>>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddHashSetParameter(() => UserExpands);
            values.AddHashSetParameter(() => Usernames);
            return await ExecuteDefaultPostAsync("user/whois", values);
        }
    }
}
