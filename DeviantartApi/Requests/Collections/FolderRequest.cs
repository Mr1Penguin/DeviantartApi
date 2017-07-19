using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace DeviantartApi.Requests.Collections
{
    public class FolderRequest : PageableRequest<Objects.Folder>
    {
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
        public string UserName { get; set; }

        private string _folderId;

        public FolderRequest(string folderId)
        {
            _folderId = folderId;
        }

        public override Task<Response<Objects.Folder>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => UserName);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            values.AddHashSetParameter(() => UserExpands);
            values.AddParameter(() => MatureContent);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"collections/{_folderId}?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
