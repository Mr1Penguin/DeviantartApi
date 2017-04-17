using DeviantartApi.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Requests.Comments
{
    public abstract class CommentsRequest : PageableRequest<Objects.Comments>
    {
        [Parameter("commentid")]
        public string CommentId { get; set; }

        [Parameter("maxdepth")]
        public uint MaxDepth { get; set; }

        protected string Argument { get; set; }
    }
}
