using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash
{
    public class SpaceRequest : Request<Objects.Space>
    {
        public override async Task<Response<Objects.Space>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"stash/space?");
        }
    }
}
