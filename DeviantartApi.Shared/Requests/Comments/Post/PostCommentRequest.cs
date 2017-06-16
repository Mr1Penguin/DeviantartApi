using DeviantartApi.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Requests.Comments.Post
{
    public abstract class PostCommentRequest : Request<Objects.Comment>
    {
        [Parameter("commentid")]
        public string CommentId { get; set; }

        [Parameter("body")]
        public string Body { get; set; }

        protected string Argument;
    }
}
