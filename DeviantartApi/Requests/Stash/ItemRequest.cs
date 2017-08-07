using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash
{
    public class ItemRequest : Request<Objects.StashItem>
    {
        public enum Error
        {
            ItemNotFound = 0
        }

        [Parameter("ext_submission")]
        public bool ExtSubmission { get; set; }

        [Parameter("ext_camera")]
        public bool ExtCamera { get; set; }

        [Parameter("ext_stats")]
        public bool ExtStats { get; set; }

        public string ItemId { get; set; }

        public ItemRequest(string itemid)
        {
            ItemId = itemid;
        }

        public override async Task<Response<Objects.StashItem>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var = new Dictionary<string, string>();
            values.AddParameter(() => ExtSubmission);
            values.AddParameter(() => ExtCamera);
            values.AddParameter(() => ExtStats);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"stash/item/{ItemId}?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
