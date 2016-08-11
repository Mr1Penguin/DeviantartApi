using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse
{
    public class HotRequest : PageableRequest<Objects.Browse>
    {
        public enum UserExpand
        {
            Watch
        }

        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();
        public bool LoadMature { get; set; }
        /// <summary>
        /// Default path: "/"
        /// </summary>
        public string CategoryPath { get; set; } = "/";

        public override async Task<Response<Objects.Browse>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync("browse/hot?" + 
                                                $"category_path={CategoryPath}" + 
                                                (Offset != null ? $"&offset={Offset}" : "") + 
                                                (Limit != null ? $"&limit={Limit}" : "") +
                                                $"&expand={string.Join(",", UserExpands.Select(x => "user." + x.ToString().ToLower()).ToList())}" +
                                                $"&mature_content={LoadMature.ToString().ToLower()}");
        }
    }
}
