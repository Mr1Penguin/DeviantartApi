using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace DeviantartApi.Requests.Collections
{
    public class FoldersRequest : PageableRequest<Objects.ArrayOfResults<Objects.SubObjects.Profile.CollectionFolder>>
    {
        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        [Parameter("username")]
        public string UserName { get; set; }

        [Parameter("calculate_size")]
        public bool CalculateSize { get; set; }

        [Parameter("ext_preload")]
        public bool ExtPreload { get; set; }

        public override Task<Response<Objects.ArrayOfResults<Objects.SubObjects.Profile.CollectionFolder>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => MatureContent);
            values.AddParameter(() => UserName);
            values.AddParameter(() => CalculateSize);
            values.AddParameter(() => ExtPreload);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync("collections/folders?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
