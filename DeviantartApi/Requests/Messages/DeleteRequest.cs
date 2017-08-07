using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Messages
{
    public class DeleteRequest : Request<Objects.BaseObject>
    {
        [Parameter("folderid")]
        public string FolderId { get; set; }

        [Parameter("messageid")]
        public string MessageId { get; set; }

        [Parameter("stackid")]
        public string StackId { get; set; }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => FolderId);
            values.AddParameter(() => MessageId);
            values.AddParameter(() => StackId);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultPostAsync("messages/delete", values, cancellationToken);
        }
    }
}
