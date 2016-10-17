using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash
{
    public class MoveRequest : Request<Objects.MoveStackResult>
    {
        public enum Error
        {
            StackNotFound = 0,
            InvalidTargetStack = 1
        }

        [Parameter("targetid")]
        public string TargetId { get; set; }

        private string _stackid;

        public MoveRequest(string stackid)
        {
            _stackid = stackid;
        }

        public override async Task<Response<Objects.MoveStackResult>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => TargetId);
            return await ExecuteDefaultPostAsync("stash/move/{_stackid}", values);
        }
    }
}
