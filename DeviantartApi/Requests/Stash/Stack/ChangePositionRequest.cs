using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash
{
    public class ChangePositionRequest : Request<Objects.BaseObject>
    {
        [Parameter("position")]
        public int Position { get; set; }

        private string _stackid;

        public ChangePositionRequest(string stackid)
        {
            _stackid = stackid;
        }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => Position);
            return await ExecuteDefaultPostAsync("stash/position/{_stackid}", values);
        }
    }
}
