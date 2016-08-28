using System.Threading.Tasks;

namespace DeviantartApi.Requests.Comments.Deviation
{
    public class DeviationCommentsRequest : PageableRequest<Objects.Comments>
    {
        public string CommentId { get; set; }
        public uint MaxDepth { get; set; }

        private string _deviationId;

        public DeviationCommentsRequest(string deviationId)
        {
            _deviationId = deviationId;
        }

        public override async Task<Response<Objects.Comments>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"comments/deviation/{_deviationId}?" +
                                                $"commentid={CommentId}" +
                                                $"&maxdepth={MaxDepth}" +
                                                (Offset != null ? $"&offset={Offset}" : "") +
                                                (Limit != null ? $"&limit={Limit}" : ""));
        }
    }
}
