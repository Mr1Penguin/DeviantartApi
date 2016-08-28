using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Deviation
{
    public class DeviationRequest : Request<Objects.Deviation>
    {
        public enum Error
        {
            DeviationNotFound = 0,
            DeviationIsNotOwnedByThisUser = 1
        }

        public enum UserExpand
        {
            Watch
        }

        public enum DeviationExpand
        {
            Challenge
        }

        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();
        public HashSet<DeviationExpand> DeviationExpands { get; set; } = new HashSet<DeviationExpand>();

        private string _deviationId;

        public DeviationRequest(string deviationId)
        {
            _deviationId = deviationId;
        }

        public override async Task<Response<Objects.Deviation>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"deviation/{_deviationId}?" + "expand=" +
                                                string.Join(",", UserExpands.Select(x => "user." + x.ToString().ToLower()).ToList()) + "," + //legal on 2016-07-18
                                                string.Join(",", DeviationExpands.Select(x => "deviation." + x.ToString().ToLower()).ToList()));
        }
    }
}
