﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse.User
{
    public class JournalsRequest : PageableRequest<Objects.Browse>
    {
        public enum UserExpand
        {
            Watch
        }

        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();

        public bool Featured { get; set; } = true;
        public string UserName { get; set; }
        public bool LoadMature { get; set; }

        public override async Task<Response<Objects.Browse>> ExecuteAsync()
        {
            return await ExecuteDefaultAsync("browse/user/journals" +
                                             $"?featured={Featured.ToString().ToLower()}" +
                                             $"&username={UserName}" +
                                             (Offset != null ? $"&offset={Offset}" : "") +
                                             (Limit != null ? $"&limit={Limit}" : "") +
                                             $"&expand={string.Join(",", UserExpands.Select(x => "user." + x.ToString().ToLower()).ToList())}" +
                                             $"&mature_content={LoadMature.ToString().ToLower()}");
        }
    }
}
