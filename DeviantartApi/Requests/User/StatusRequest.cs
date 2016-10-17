using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User
{
    public class StatusRequest : Request<Objects.Status>
    {
        private string _statusId;

        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        public StatusRequest(string statusId)
        {
            _statusId = statusId;
        }

        public override async Task<Response<Objects.Status>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => MatureContent);
            return await ExecuteDefaultGetAsync($"user/statuses/{_statusId}?" + values.ToGetParameters());
        }
    }
}
