using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Gallery
{
    public class AllRequest : PageableRequest<Objects.ArrayOfResults<Objects.Deviation>>
    {
        [Parameter("username")]
        public string Username { get; set; }

        public override async Task<Response<Objects.ArrayOfResults<Objects.Deviation>>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => Username);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            return await ExecuteDefaultGetAsync($"gallery/all?" + values.ToGetParameters());
        }
    }
}
