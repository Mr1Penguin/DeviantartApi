using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Messages
{
    public class FeedbackRequest : PageableRequest<Objects.ArrayOfResults<Objects.Message>>
    {
        enum MessagesType
        {
            Comments,
            Replies,
            Activity
        }

        [Parameter("type")]
        MessagesType Type { get; set; }

        [Parameter("folderid")]
        public string FolderId { get; set; }

        [Parameter("stack")]
        public bool? Stack { get; set; }

        public override Task<Response<Objects.ArrayOfResults<Objects.Message>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => FolderId);
            values.AddParameter(() => Stack);
            values.AddParameter(() => Type);
            values.AddParameter(() => Offset);
            values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"messages/feedback?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
