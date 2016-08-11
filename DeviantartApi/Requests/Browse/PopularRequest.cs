using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse
{
    public class PopularRequest : PageableRequest<Objects.Browse>
    {
        public enum TimeRange
        {
            tDefault,
            t8hr,
            t24ht,
            t3days,
            t1week,
            t1month,
            tAlltime
        }

        public enum UserExpand
        {
            Watch
        }

        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();
        public TimeRange SelectedTimeRange { get; set; } = TimeRange.tDefault;

        public bool LoadMature { get; set; }
        /// <summary>
        /// Default path: "/"
        /// </summary>
        public string CategoryPath { get; set; } = "/";
        public string Query { get; set; }

        public override async Task<Response<Objects.Browse>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync("browse/popular?" +
                                                $"category_path={CategoryPath}" +
                                                $"&q={Query}" +
                                                (Offset != null ? $"&offset={Offset}" : "") +
                                                (Limit != null ? $"&limit={Limit}" : "") +
                                                $"&expand={string.Join(",", UserExpands.Select(x => "user." + x.ToString().ToLower()).ToList())}" +
                                                (SelectedTimeRange == TimeRange.tDefault ? "" : "&timerange" + SelectedTimeRange.ToString().Substring(1)) +
                                                $"&mature_content={LoadMature.ToString().ToLower()}");
        }
    }
}
