using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Deviation
{
    using System.Threading;

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

        [Parameter("user")]
        [Expands]
        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();

        [Parameter("deviation")]
        [Expands]
        public HashSet<DeviationExpand> DeviationExpands { get; set; } = new HashSet<DeviationExpand>();

        private string _deviationId;

        public DeviationRequest(string deviationId)
        {
            _deviationId = deviationId;
        }

        public override async Task<Response<Objects.Deviation>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddHashSetParameter(() => UserExpands);
            values.AddHashSetParameter(() => DeviationExpands);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"deviation/{_deviationId}?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
