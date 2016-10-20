using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash
{
    public class UpdateRequest : Request<Objects.BaseObject>
    {
        public enum Error
        {
            StackNotFound = 0
        }

        [Parameter("title")]
        public string Title { get; set; }

        [Parameter("description")]
        public string Description { get; set; }

        private string _stackid;

        public UpdateRequest(string stackid)
        {
            _stackid = stackid;
        }

        public override async Task<Response<Objects.BaseObject>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => Title);
            values.AddParameter(() => Description);
            return await ExecuteDefaultPostAsync($"stash/update/{_stackid}", values);
        }
    }
}