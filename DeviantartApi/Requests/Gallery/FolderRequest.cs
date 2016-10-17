using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Gallery
{
    public class FolderRequest : PageableRequest<Objects.ArrayOfResults<Objects.Deviation>>
    {
        public enum SortMode
        {
            Popular,
            Newest
        }

        public enum UserExpand
        {
            Watch
        }

        [Parameter("user")]
        [Expands]
        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();

        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        [Parameter("username")]
        public string Username { get; set; }

        [Parameter("mode")]
        public SortMode Mode { get; set; }

        private string _folderid;

        public FolderRequest(string folderid)
        {
            _folderid = folderid;
        }

        public override async Task<Response<Objects.ArrayOfResults<Objects.Deviation>>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => Mode);
            values.AddParameter(() => Username);
            values.AddParameter(() => MatureContent);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            values.AddHashSetParameter(() => UserExpands);
            return await ExecuteDefaultGetAsync($"gallery/{_folderid}?" + values.ToGetParameters());
        }
    }
}
