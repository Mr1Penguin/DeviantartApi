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
        public bool ExtItem { get; set; }

        public SiblingsRequest(string commentId)
        {
            CommentId = commentId;
        }

        public override async Task<Response<Objects.Siblings>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => ExtItem);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"comments/{CommentId}/siblings?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
