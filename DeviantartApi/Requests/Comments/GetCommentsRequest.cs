using DeviantartApi.Attributes;

namespace DeviantartApi.Requests.Comments
{
    public abstract class GetCommentsRequest : PageableRequest<Objects.Comments>
    {
        [Parameter("commentid")]
        public string CommentId { get; set; }

        [Parameter("maxdepth")]
        public uint? MaxDepth { get; set; }

        public string Argument { get; set; }
    }
}
