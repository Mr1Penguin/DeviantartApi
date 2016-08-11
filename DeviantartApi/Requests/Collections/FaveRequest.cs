using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Collections
{
    public class FaveRequest : Request<Objects.Fave>
    {
        public string DeviationId { get; set; }
        public HashSet<string> FolderIds { get; set; } = new HashSet<string>();

        public override async Task<Response<Objects.Fave>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("deviationid", DeviationId);
            ulong i = 0;
            foreach (var folderId in FolderIds)
                values.Add($"folderid[{i++}]", folderId);
            return await ExecuteDefaultPostAsync("collections/fave", values);
        }
    }
}
