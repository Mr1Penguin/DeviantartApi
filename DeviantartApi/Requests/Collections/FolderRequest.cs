using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public override async Task<Response<Objects.Folder>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => UserName);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            values.AddHashSetParameter(() => UserExpands);
            values.AddParameter(() => MatureContent);
            return await ExecuteDefaultGetAsync($"collections/{_folderId}?" + values.ToGetParameters());
        }
    }
}
