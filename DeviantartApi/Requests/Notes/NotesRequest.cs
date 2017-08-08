using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes
{
    public class NotesRequest : PageableRequest<Objects.ArrayOfResults<Objects.Note>>
    {
        [Parameter("folderid")]
        public string FolderId { get; set; }

        public override Task<Response<Objects.ArrayOfResults<Objects.Note>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => FolderId);
            values.AddParameter(() => Offset);
            values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync($"notes?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
