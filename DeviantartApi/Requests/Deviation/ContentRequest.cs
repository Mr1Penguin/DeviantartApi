using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Deviation
{
    public class ContentRequest : Request<Objects.Content>
    {
        public enum Error
        {
            DeviatonNotFound = 0,
            UnsupportedDeviationType = 1
        }

        [Parameter("deviationid")]
        public string DeviationId { get; set; }

        public override async Task<Response<Objects.Content>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => DeviationId);
            return await ExecuteDefaultGetAsync($"deviation/content?" + values.ToGetParameters());
        }
    }
}
