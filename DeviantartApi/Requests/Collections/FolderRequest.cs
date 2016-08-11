using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Collections
{
    public class FolderRequest : PageableRequest<Objects.CollectionFolder>
    {

        public enum UserExpand
        {
            Watch
        }

        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();

        public bool LoadMature { get; set; }

        public string UserName { get; set; }

        private string _folderId;

        public FolderRequest(string folderId)
        {
            _folderId = folderId;
        }

        public override async Task<Response<Objects.CollectionFolder>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"collections/{_folderId}?" +
                                                $"username={UserName}" +
                                                (Offset != null ? $"&offset={Offset}" : "") +
                                                (Limit != null ? $"&limit={Limit}" : "") +
                                                $"&expand={string.Join(",", UserExpands.Select(x => "user." + x.ToString().ToLower()).ToList())}" +
                                                $"&mature_content={LoadMature.ToString().ToLower()}");
        }
    }
}
