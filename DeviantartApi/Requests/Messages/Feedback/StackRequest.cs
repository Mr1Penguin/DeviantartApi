using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Messages.Feedback
{
    public class StackRequest : PageableRequest<Objects.ArrayOfResults<Objects.SubObjects.Message>>
    {
        private string _stackid;

        public StackRequest(string stackid)
        {
            _stackid = stackid;
        }

        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.Message>>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            return await ExecuteDefaultGetAsync($"messages/feedback/{_stackid}?" + values.ToGetParameters());
        }
    }
}
