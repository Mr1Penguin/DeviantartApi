using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Comments.Comment
{
    public class SiblingsRequest : PageableRequest<Objects.Siblings>
    {
        private string _commentId;

        public bool ExtItem { get; set; }

        public SiblingsRequest(string commentId) {
            _commentId = commentId;
        }

        public override async Task<Response<Objects.Siblings>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"comments/{_commentId}/siblings?" +
                                                $"&ext_item={ExtItem.ToString().ToLower()}" + 
                                                (Offset != null ? $"&offset={Offset}" : "") +
                                                (Limit != null ? $"&limit={Limit}" : ""));
        }
    }
}
