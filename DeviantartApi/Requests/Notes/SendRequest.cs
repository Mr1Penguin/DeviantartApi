using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Notes
{
    public class SendRequest : Request<Objects.ArrayOfResults<Objects.SendNoteResponse>>
    {
        [Parameter("to")]
        public HashSet<string> To { get; set; }

        [Parameter("subject")]
        public string Subject { get; set; }

        [Parameter("body")]
        public string Body { get; set; }

        [Parameter("noteid")]
        public string NoteId { get; set; }

        public SendRequest(IEnumerable<string> to)
        {
            To = new HashSet<string>(to);
        }

        public override Task<Response<Objects.ArrayOfResults<Objects.SendNoteResponse>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddHashSetParameter(() => To);
            values.AddParameter(() => Subject);
            values.AddParameter(() => Body);
            values.AddParameter(() => NoteId);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultPostAsync("notes/send", values, cancellationToken);
        }
    }
}
