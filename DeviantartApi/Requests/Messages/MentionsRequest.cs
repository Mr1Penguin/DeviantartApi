using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Messages
{
    public class MentionsRequest : PageableRequest<Objects.ArrayOfResults<Objects.Message>>
    {
        [Parameter("folderid")]
        public string FolderId { get; set; }

        [Parameter("stack")]
        public bool Stack { get; set; }

        public override async Task<Response<Objects.ArrayOfResults<Objects.Message>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => FolderId);
            values.AddParameter(() => Stack);
            if (Cursor != null) values.AddParameter(() => Cursor);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"messages/mentions?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
