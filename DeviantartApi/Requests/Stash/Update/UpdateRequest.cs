using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash.Update
{
    public class UpdateRequest : Request<Objects.BaseObject>
    {
        public enum Error
        {
            StackNotFound = 0
        }

        public string Title { get; set; }
        public string Description { get; set; }

        private string _stackid;

        public UpdateRequest(string stackid)
        {
            _stackid = stackid;
        }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("title", Title);
            values.Add("description", Description);
            return await ExecuteDefaultPostAsync("stash/update/{_stackid}", values);
        }
    }
}
