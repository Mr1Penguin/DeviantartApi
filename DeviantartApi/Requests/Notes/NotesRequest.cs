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

        public override async Task<Response<Objects.ArrayOfResults<Objects.Note>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => FolderId);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"notes?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
