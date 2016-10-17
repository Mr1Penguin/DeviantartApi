using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse.User
{
    public class JournalsRequest : PageableRequest<Objects.Browse>
    {
        public enum UserExpand
        {
            Watch
        }

        [Parameter("user")]
        [Expands]
        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();

        [Parameter("featured")]
        public bool Featured { get; set; } = true;

        [Parameter("username")]
        public string Username { get; set; }

        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        public override async Task<Response<Objects.Browse>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => Featured);
            values.AddParameter(() => Username);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            values.AddHashSetParameter(() => UserExpands);
            values.AddParameter(() => MatureContent);
            return await ExecuteDefaultGetAsync("browse/user/journals?" + values.ToGetParameters());
        }
    }
}
