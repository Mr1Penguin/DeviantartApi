using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Messages
{
    using System.Threading;

    public class MentionsRequest : PageableRequest<Objects.ArrayOfResults<Objects.SubObjects.Message>>
    {
        [Parameter("folderid")]
        public string FolderId { get; set; }

        [Parameter("stack")]
        public bool Stack { get; set; }

        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.Message>>> ExecuteAsync(CancellationToken cancellationToken)
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
