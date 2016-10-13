using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash.Item
{
    public class ItemRequest : Request<Objects.StashItem>
    {
        public enum Error
        {
            ItemNotFound = 0
        }

        public bool ExtSubmission { get; set; }
        public bool ExtCamera { get; set; }
        public bool ExtStats { get; set; }

        private string _itemid;

        public ItemRequest(string itemid)
        {
            _itemid = itemid;
        }

        public override async Task<Response<Objects.StashItem>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"stash/item/{_itemid}?"
                + $"ext_submission={ExtSubmission.ToString().ToLower()}"
                + "&" + $"ext_camera={ExtCamera.ToString().ToLower()}"
                + "&" + $"ext_stats={ExtStats.ToString().ToLower()}");
        }
    }
}
