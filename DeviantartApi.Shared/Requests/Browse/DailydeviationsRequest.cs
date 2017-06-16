using DeviantartApi.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse
{
    using System.Threading;

    public class DailyDeviationsRequest : Request<Objects.ArrayOfResults<Objects.Deviation>>
    {
        public enum UserExpand
        {
            Watch
        }

        [Parameter("user")]
        [Expands]
        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();

        /// <summary>
        /// Day to browse. Left null for today.
        /// </summary>
        [Parameter("date")]
        [DateTimeFormat("yyyy-MM-dd")]
        public DateTime? Day { get; set; } = null;

        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        public override async Task<Response<Objects.ArrayOfResults<Objects.Deviation>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => Day);
            values.AddHashSetParameter(() => UserExpands);
            values.AddParameter(() => MatureContent);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync("browse/dailydeviations?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
