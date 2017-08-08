using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User.Friends
{
    public class SearchRequest : Request<Objects.ArrayOfResults<Objects.User>>
    {
        [Parameter("username")]
        public string Username { get; set; }

        [Parameter("query")]
        public string Query { get; set; }

        public SearchRequest(string query)
        {
            Query = query;
        }

        public override Task<Response<Objects.ArrayOfResults<Objects.User>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => Username);
            values.AddParameter(() => Query);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync("user/friends/search?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
