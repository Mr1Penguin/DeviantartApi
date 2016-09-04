using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Messages.Mentions
{
    public class StackRequest : PageableRequest<Objects.MessagesFeed>
    {
        private string _stackid;

        public StackRequest(string stackid)
        {
            _stackid = stackid;
        }

        public override async Task<Response<Objects.MessagesFeed>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"messages/mentions/{_stackid}?"
                + (Offset != null ? $"&offset={Offset}" : "") + (Limit != null ? $"&limit={Limit}" : ""));
        }
    }
}
