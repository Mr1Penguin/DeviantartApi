using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User.Statuses
{
    public class PostStatusRequest : Request<Objects.Status>
    {
        [Parameter("body")]
        public string Body { get; set; }

        [Parameter("id")]
        public string Id { get; set; }

        [Parameter("parentid")]
        public string ParentId { get; set; }

        [Parameter("stashid")]
        public string StashId { get; set; }

        public override Task<Response<Objects.Status>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(Body))
                values.AddParameter(() => Body);
            if (!string.IsNullOrWhiteSpace(Id))
                values.AddParameter(() => Id);
            if (!string.IsNullOrWhiteSpace(ParentId))
                values.AddParameter(() => ParentId);
            if (!string.IsNullOrWhiteSpace(StashId))
                values.AddParameter(() => StashId);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultPostAsync("user/statuses/post", values, cancellationToken);
        }
    }
}
