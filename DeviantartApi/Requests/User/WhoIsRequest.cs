using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
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
        public HashSet<string> Usernames { get; set; }

        public WhoIsRequest(IEnumerable<string> usernames)
        {
            Usernames = new HashSet<string>(usernames);
        }

        public override Task<Response<Objects.ArrayOfResults<Objects.User>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddHashSetParameter(() => UserExpands);
            values.AddHashSetParameter(() => Usernames);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultPostAsync("user/whois", values, cancellationToken);
        }
    }
}
