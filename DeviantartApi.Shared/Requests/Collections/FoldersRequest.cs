using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Collections
{
    using System.Threading;

    public class FoldersRequest : PageableRequest<Objects.ArrayOfResults<Objects.SubObjects.CollectionFolder>>
    {
        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        [Parameter("username")]
        public string UserName { get; set; }

        [Parameter("calculate_size")]
        public bool CalculateSize { get; set; }

        [Parameter("mature_content")]
        public bool ExtPreload { get; set; }

        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.CollectionFolder>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => MatureContent);
            values.AddParameter(() => UserName);
            values.AddParameter(() => CalculateSize);
            values.AddParameter(() => ExtPreload);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync("collections/folders?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
