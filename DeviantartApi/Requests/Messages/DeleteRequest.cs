using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Messages
{
    public class DeleteRequest : Request<Objects.PostResponse>
    {
        [Parameter("folderid")]
        public string FolderId { get; set; }

        [Parameter("messageid")]
        public string MessageId { get; set; }

        [Parameter("stackid")]
        public string StackId { get; set; }

        public override Task<Response<Objects.PostResponse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => FolderId);
            values.AddParameter(() => MessageId);
            values.AddParameter(() => StackId);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultPostAsync("messages/delete", values, cancellationToken);
        }
    }
}
