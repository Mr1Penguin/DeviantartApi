using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace DeviantartApi.Requests.Collections
{
    public class FolderRequest : PageableRequest<Objects.Folder>
    {
        protected virtual string FolderPath { get; set; } = "collections";

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

        private string _folderId;

        public FolderRequest(string folderId)
        {
            _folderId = folderId;
        }

        protected virtual void FillValues(Dictionary<string, string> values)
        {
            values.AddParameter(() => Username);
            values.AddHashSetParameter(() => UserExpands);
            values.AddParameter(() => MatureContent);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
        }

        public override Task<Response<Objects.Folder>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            FillValues(values);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"{FolderPath}/{_folderId}?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
