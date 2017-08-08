using DeviantartApi.Attributes;

namespace DeviantartApi.Requests.Comments.Post
{
    public abstract class PostCommentRequest : Request<Objects.Comment>
    {
        [Parameter("commentid")]
        public string CommentId { get; set; }

        [Parameter("body")]
        public string Body { get; set; }

        public string Argument;
    }
}
