using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Deviation
{
    public class WhoFavedRequest : PageableRequest<Objects.ArrayOfResults<Objects.SubObjects.FavedUser>>
    {
        public enum UserExpand
        {
            Details,
            Geo,
            Profile,
            Stats
        }

        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();
        public string DeviationId { get; set; }

        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.FavedUser>>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"deviation/whofaved?deviationid={DeviationId}"
                + (Offset != null ? $"&offset={Offset}" : "") + (Limit != null ? $"&limit={Limit}" : "")
                + "&expand=" + string.Join(",", UserExpands.Select(x => "user." + x.ToString().ToLower()).ToList()));
        }
    }
}
