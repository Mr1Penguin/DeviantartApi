using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash
{
    using System.Threading;

    public class ChangePositionRequest : Request<Objects.BaseObject>
    {
        [Parameter("position")]
        public int Position { get; set; }

        private string _stackid;

        public ChangePositionRequest(string stackid)
        {
            _stackid = stackid;
        }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => Position);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultPostAsync("stash/position/{_stackid}", values, cancellationToken);
        }
    }
}
