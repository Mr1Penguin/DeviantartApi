using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace DeviantartApi.Requests.Gallery
{
    public class FolderRequest : PageableRequest<Objects.Folder>
    {
        public enum SortMode
        {
            Popular,
            Newest
        }

        public enum UserExpand
        {
            Watch
        }

        [Parameter("user")]
        [Expands]
        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();

        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        [Parameter("username")]
        public string Username { get; set; }

        [Parameter("mode")]
        public SortMode Mode { get; set; }

        private string _folderid;

        public FolderRequest(string folderid)
        {
            _folderid = folderid;
        }

        public override Task<Response<Objects.Folder>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => Mode);
            values.AddParameter(() => Username);
            values.AddParameter(() => MatureContent);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            values.AddHashSetParameter(() => UserExpands);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"gallery/{_folderid}?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
