using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User.Profile
{
    public class UsernameRequest : Request<Objects.Profile>
    {
        public enum ErrorCode
        {
            AccountHasBeenSuspended = 0,
            AccountIsInactive = 1,
            UserNotFound = 2
        }

        public enum UserExpand
        {
            Details,
            Geo,
            Stats
        }

        public string Username { get; set; }

        [Parameter("user")]
        [Expands]
        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();

        [Parameter("ext_collections")]
        public bool? ExtCollections { get; set; }

        [Parameter("ext_galleries")]
        public bool? ExtGalleries { get; set; }

        public UsernameRequest(string username)
        {
            Username = username;
        }

        public override Task<Response<Objects.Profile>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => ExtCollections);
            values.AddParameter(() => ExtGalleries);
            values.AddHashSetParameter(() => UserExpands);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"user/profile/{Username}" + values.ToGetParameters(), cancellationToken);
        }
    }
}
