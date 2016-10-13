using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash.Move
{
    public class MoveStackRequest : Request<Objects.MoveStackResult>
    {
        public enum Error
        {
            StackNotFound = 0,
            InvalidTargetStack = 1
        }

        public string TargetId { get; set; }

        private string _stackid;

        public MoveStackRequest(string stackid)
        {
            _stackid = stackid;
        }

        public override async Task<Response<Objects.MoveStackResult>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("targetid", TargetId);
            return await ExecuteDefaultPostAsync("stash/move/{_stackid}", values);
        }
    }
}
