using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash.Position
{
    public class ChangeStackPositionRequest : Request<Objects.BaseObject>
    {
        public int Position { get; set; }

        private string _stackid;

        public ChangeStackPositionRequest(string stackid)
        {
            _stackid = stackid;
        }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("position", Position.ToString().ToLower());
            return await ExecuteDefaultPostAsync("stash/position/{_stackid}", values);
        }
    }
}
