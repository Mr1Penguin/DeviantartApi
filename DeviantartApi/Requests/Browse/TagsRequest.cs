using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse
{
    public class TagsRequest : PageableRequest<Objects.Browse>
    {
        public enum UserExpand
        {
            Watch
        }

        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();

        public bool LoadMature { get; set; }
        public string Tag { get; set; }

        public override async Task<Response<Objects.Browse>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync("browse/tags?" +
                                                $"&tag={Tag}" +
                                                (Offset != null ? $"&offset={Offset}" : "") +
                                                (Limit != null ? $"&limit={Limit}" : "") +
                                                $"&expand={string.Join(",", UserExpands.Select(x => "user." + x.ToString().ToLower()).ToList())}" +
                                                $"&mature_content={LoadMature.ToString().ToLower()}");
        }
    }
}
