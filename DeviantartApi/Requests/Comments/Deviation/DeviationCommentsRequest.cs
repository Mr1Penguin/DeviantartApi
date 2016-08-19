using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Comments.Deviation
{
    public class DeviationCommentsRequest : PageableRequest<Objects.DeviationComments>
    {
        public string CommentId { get; set; }
        public uint MaxDepth { get; set; }

        private string _deviationId;

        public DeviationCommentsRequest(string deviationId)
        {
            _deviationId = deviationId;
        }

        public override async Task<Response<Objects.DeviationComments>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"comments/deviation/{_deviationId}?" + 
                                                $"commentid={CommentId}" + 
                                                $"&maxdepth={MaxDepth}" +
                                                (Offset != null ? $"&offset={Offset}" : "") +
                                                (Limit != null ? $"&limit={Limit}" : ""));
        }
    }
}
