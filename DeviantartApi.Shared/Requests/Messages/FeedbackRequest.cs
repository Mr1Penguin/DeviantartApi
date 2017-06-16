using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Messages
{
    using System.Threading;

    public class FeedbackRequest : PageableRequest<Objects.ArrayOfResults<Objects.SubObjects.Message>>
    {
        [Parameter("folderid")]
        public string FolderId { get; set; }

        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.Message>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => FolderId);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"messages/feedback?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
