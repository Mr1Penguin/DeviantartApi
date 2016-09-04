using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Messages
{
    public class DeleteRequest : Request<Objects.BaseObject>
    {
        public string FolderId { get; set; }
        public string MessageId { get; set; }
        public string StackId { get; set; }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            ulong i;
            values.Add("folderid", FolderId);
            values.Add("messageid", MessageId);
            values.Add("stackid", StackId);
            return await ExecuteDefaultPostAsync("messages/delete", values);
        }
    }
}
