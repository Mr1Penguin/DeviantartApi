using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User
{
    public class PostStatusRequest : Request<Objects.StatusPostResponse>
    {
        [Parameter("body")]
        public string Body { get; set; }

        [Parameter("id")]
        public string Id { get; set; }

        [Parameter("parentid")]
        public string ParentId { get; set; }

        [Parameter("stashid")]
        public string StashId { get; set; }

        public override async Task<Response<Objects.StatusPostResponse>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(Body))
                values.AddParameter(() => Body);
            if (string.IsNullOrWhiteSpace(Id))
                values.AddParameter(() => Id);
            if (string.IsNullOrWhiteSpace(ParentId))
                values.AddParameter(() => ParentId);
            if (string.IsNullOrWhiteSpace(StashId))
                values.AddParameter(() => StashId);
            return await ExecuteDefaultPostAsync("user/statuses/post", values);
        }
    }
}
