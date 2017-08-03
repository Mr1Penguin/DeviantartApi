using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse.User
{
    /// <summary>
    /// Browse journals of a user
    /// </summary>
    public class JournalsRequest : PageableRequest<Objects.Browse>
    {
        public enum UserExpand
        {
            Watch
        }

        [Parameter("user")]
        [Expands]
        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();

        /// <summary>
        /// Fetch only featured or not
        /// </summary>
        [Parameter("featured")]
        public bool Featured { get; set; }

        /// <summary>
        /// The username of the user to fetch journals for.
        /// </summary>
        [Parameter("username")]
        public string Username { get; set; }

        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JournalsRequest"/> class.
        /// </summary>
        /// <param name="username">The username of the user to fetch journals for.</param>
        public JournalsRequest(string username)
        {
            Username = username;
        }

        public override async Task<Response<Objects.Browse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => Featured);
            values.AddParameter(() => Username);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            values.AddHashSetParameter(() => UserExpands);
            values.AddParameter(() => MatureContent);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync("browse/user/journals?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
