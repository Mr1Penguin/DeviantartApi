using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Comments
{
    public class SiblingsRequest : PageableRequest<Objects.Siblings>
    {
        private string _commentId;

        [Parameter("ext_item")]
        public bool ExtItem { get; set; }

        public SiblingsRequest(string commentId)
        {
            _commentId = commentId;
        }

        public override async Task<Response<Objects.Siblings>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => ExtItem);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            return await ExecuteDefaultGetAsync($"comments/{_commentId}/siblings?" + values.ToGetParameters());
        }
    }
}
