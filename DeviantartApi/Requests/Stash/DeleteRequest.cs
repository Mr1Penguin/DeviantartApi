using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash
{
    public class DeleteRequest : Request<Objects.BaseObject>
    {
        public enum Error
        {
            DeviationNotFound = 0
        }

        [Parameter("itemid")]
        public int ItemId { get; set; }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => ItemId);
            return await ExecuteDefaultPostAsync("stash/delete", values);
        }
    }
}
