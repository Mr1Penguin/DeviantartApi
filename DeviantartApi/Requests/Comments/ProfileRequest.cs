using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Comments.Profile
{
    using System.Threading;

    public class ProfileRequest : PageableRequest<Objects.Comments>
    {
        [Parameter("commentid")]
        public string CommentId { get; set; }

        [Parameter("maxdepth")]
        public uint MaxDepth { get; set; }

        private string _username;

        public ProfileRequest(string username)
        {
            _username = username;
        }

        public override async Task<Response<Objects.Comments>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => CommentId);
            values.AddParameter(() => MaxDepth);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"comments/profile/{_username}?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
