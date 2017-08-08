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
        public bool? Stack { get; set; }

        public override Task<Response<Objects.ArrayOfResults<Objects.Message>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => FolderId);
            values.AddParameter(() => Stack);
            values.AddParameter(() => Cursor);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"messages/mentions?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
