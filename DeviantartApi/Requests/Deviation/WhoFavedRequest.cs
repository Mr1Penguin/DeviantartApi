using DeviantartApi.Attributes;
using System.Collections.Generic;
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

        [Parameter("user")]
        [Expands]
        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();

        [Parameter("deviationid")]
        public string DeviationId { get; set; }

        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.FavedUser>>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => DeviationId);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            values.AddHashSetParameter(() => UserExpands);
            return await ExecuteDefaultGetAsync($"deviation/whofaved?" + values.ToGetParameters());
        }
    }
}
