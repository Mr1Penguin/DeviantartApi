using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Feed
{
    public class UpdateRequest : Request<Objects.PostResponse>
    {
        [Parameter("include[statuses]")]
        public bool? Statuses { get; set; }

        [Parameter("include[deviations]")]
        public bool? Deviations { get; set; }

        [Parameter("include[journals]")]
        public bool? Journals { get; set; }

        [Parameter("include[group_deviations]")]
        public bool? GroupDeviations { get; set; }

        [Parameter("include[collections]")]
        public bool? Collections { get; set; }

        [Parameter("include[misc]")]
        public bool? Misc { get; set; }

        public override Task<Response<Objects.PostResponse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => Statuses);
            values.AddParameter(() => Deviations);
            values.AddParameter(() => Journals);
            values.AddParameter(() => GroupDeviations);
            values.AddParameter(() => Collections);
            values.AddParameter(() => Misc);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultPostAsync("feed/settings/update", values, cancellationToken);
        }
    }
}
