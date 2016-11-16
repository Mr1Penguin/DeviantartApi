using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User.Friends
{
    using System.Threading;

    public class WatchRequest : Request<Objects.BaseObject>
    {
        public enum Error
        {
            UserNotFound = 0,
            FriendsLimitReached = 1,
            FailedToAddFriend = 2
        }

        private string _username;

        [Parameter("watch[friend]")]
        public bool Friend { get; set; }

        [Parameter("watch[deviations]")]
        public bool Deviations { get; set; }

        [Parameter("watch[journals]")]
        public bool Journals { get; set; }

        [Parameter("watch[forum_threads]")]
        public bool ForumThreads { get; set; }

        [Parameter("watch[critiques]")]
        public bool Critiques { get; set; }

        [Parameter("watch[scraps]")]
        public bool Scraps { get; set; }

        [Parameter("watch[activity]")]
        public bool Activity { get; set; }

        [Parameter("watch[collections]")]
        public bool Collections { get; set; }

        public WatchRequest(string username)
        {
            _username = username;
        }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => Friend);
            values.AddParameter(() => Deviations);
            values.AddParameter(() => Journals);
            values.AddParameter(() => ForumThreads);
            values.AddParameter(() => Critiques);
            values.AddParameter(() => Scraps);
            values.AddParameter(() => Activity);
            values.AddParameter(() => Collections);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultPostAsync($"/user/friends/watch/{_username}", values, cancellationToken);
        }
    }
}
