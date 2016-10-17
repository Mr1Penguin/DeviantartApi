using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Messages
{
    public class FeedRequest : PageableRequest<Objects.ArrayOfResults<Objects.SubObjects.Message>>
    {
        [Parameter("folderid")]
        public string FolderId { get; set; }

        [Parameter("stack")]
        public bool Stack { get; set; }

        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.Message>>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => FolderId);
            values.AddParameter(() => Stack);
            if (Cursor != null) values.AddParameter(() => Cursor);
            return await ExecuteDefaultGetAsync($"messages/feed?" + values.ToGetParameters());
        }
    }
}
