using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User.Friends.Watch
{

    public class UsernameRequest : Request<Objects.PostResponse>
    {
        public enum ErrorCode
        {
            UserNotFound = 0,
            FriendsLimitReached = 1,
            FailedToAddFriend = 2
        }

        public string Username { get; set; }

        [Parameter("watch[friend]")]
        public bool? Friend { get; set; }

        [Parameter("watch[deviations]")]
        public bool? Deviations { get; set; }

        [Parameter("watch[journals]")]
        public bool? Journals { get; set; }

        [Parameter("watch[forum_threads]")]
        public bool? ForumThreads { get; set; }

        [Parameter("watch[critiques]")]
        public bool? Critiques { get; set; }

        [Parameter("watch[scraps]")]
        public bool? Scraps { get; set; }

        [Parameter("watch[activity]")]
        public bool? Activity { get; set; }

        [Parameter("watch[collections]")]
        public bool? Collections { get; set; }

        public UsernameRequest(string username)
        {
            Username = username;
        }

        public override Task<Response<Objects.PostResponse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => Friend);
            values.AddParameter(() => Deviations);
            values.AddParameter(() => Journals);
            values.AddParameter(() => ForumThreads);
            values.AddParameter(() => Critiques);
            values.AddParameter(() => Scraps);
            values.AddParameter(() => Activity);
            values.AddParameter(() => Collections);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultPostAsync($"user/friends/watch/{Username}", values, cancellationToken);
        }
    }
}
