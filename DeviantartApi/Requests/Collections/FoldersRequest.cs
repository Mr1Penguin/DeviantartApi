using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Collections
{
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

        public override async Task<Response<Objects.ArrayOfResults<Objects.SubObjects.CollectionFolder>>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => MatureContent);
            values.AddParameter(() => UserName);
            values.AddParameter(() => CalculateSize);
            values.AddParameter(() => ExtPreload);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            return await ExecuteDefaultGetAsync("collections/folders?" + values.ToGetParameters());
        }
    }
}
