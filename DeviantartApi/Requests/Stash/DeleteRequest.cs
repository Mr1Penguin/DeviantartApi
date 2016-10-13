using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash
{
    public class DeleteRequest : Request<Objects.BaseObject>
    {
        public enum Error
        {
            DeviationNotFound = 0
        }

        public int ItemId { get; set; }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("itemid", ItemId.ToString().ToLower());
            return await ExecuteDefaultPostAsync("stash/delete", values);
        }
    }
}
