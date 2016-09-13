using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Feed.Settings
{
    public class UpdateRequest : Request<Objects.BaseObject>
    {
        public bool Statuses { get; set; }
        public bool Deviations { get; set; }
        public bool Journals { get; set; }
        public bool GroupDeviations { get; set; }
        public bool Collections { get; set; }
        public bool Misc { get; set; }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("include[statuses]", Statuses.ToString().ToLower());
            values.Add("include[deviations]", Deviations.ToString().ToLower());
            values.Add("include[journals]", Journals.ToString().ToLower());
            values.Add("include[group_deviations]", GroupDeviations.ToString().ToLower());
            values.Add("include[collections]", Collections.ToString().ToLower());
            values.Add("include[misc]", Misc.ToString().ToLower());
            return await ExecuteDefaultPostAsync("feed/settings/update", values);
        }
    }
}
