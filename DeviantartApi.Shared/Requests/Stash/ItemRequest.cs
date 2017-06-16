using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash
{
    using System.Threading;

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

        private string _itemid;

        public ItemRequest(string itemid)
        {
            _itemid = itemid;
        }

        public override async Task<Response<Objects.StashItem>> ExecuteAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => ExtSubmission);
            values.AddParameter(() => ExtCamera);
            values.AddParameter(() => ExtStats);
            cancellationToken.ThrowIfCancellationRequested();
            return await ExecuteDefaultGetAsync($"stash/item/{_itemid}?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
