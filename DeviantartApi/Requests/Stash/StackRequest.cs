using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash
{
    public class StackRequest : Request<Objects.StashMetadata>
    {
        public enum Error
        {
            StackNotFound = 0
        }

        private string _stackid;

        public StackRequest(string stackid)
        {
            _stackid = stackid;
        }

        public override async Task<Response<Objects.StashMetadata>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"stash/{_stackid}?");
        }
    }
}
