using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Comments
{
    public class SiblingsRequest : PageableRequest<Objects.Siblings>
    {
        public string CommentId { get; set; }

        [Parameter("ext_item")]
        public bool? ExtItem { get; set; }

        public SiblingsRequest(string commentId)
        {
            CommentId = commentId;
        }

        public override Task<Response<Objects.Siblings>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => ExtItem);
            values.AddParameter(() => Offset);
            values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"comments/{CommentId}/siblings?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
