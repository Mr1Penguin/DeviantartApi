using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Deviation
{
    public class DeviationRequest : Request<Objects.Deviation>
    {

        public enum UserExpand
        {
            Watch
        }

        public enum DeviationExpand
        {
            Challenge
        }

        public HashSet<UserExpand> UserExpands = new HashSet<UserExpand>();
        public HashSet<DeviationExpand> DeviationExpands = new HashSet<DeviationExpand>();

        private string _deviationId;

        public DeviationRequest(string deviationId)
        {
            _deviationId = deviationId;
        }

        public override async Task<Response<Objects.Deviation>> ExecuteAsync()
        {
            return await ExecuteDefaultAsync($"deviation/{_deviationId}?" + "expand=" +
                                             string.Join(",", UserExpands.Select(x => "user." + x.ToString().ToLower()).ToList()) + "," + //legal on 2016-07-18
                                             string.Join(",", DeviationExpands.Select(x => "deviation." + x.ToString().ToLower()).ToList()));
        }
    }
}
