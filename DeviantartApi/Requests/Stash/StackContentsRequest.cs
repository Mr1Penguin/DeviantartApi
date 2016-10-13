using System.Threading.Tasks;

namespace DeviantartApi.Requests.Stash
{
    internal class StackContentsRequest : PageableRequest<Objects.ArrayOfResults<Objects.StashMetadata>>
    {
        public enum Error
        {
            StackNotFound = 0
        }

        public bool ExtSubmission { get; set; }
        public bool ExtCamera { get; set; }
        public bool ExtStats { get; set; }

        private string _stackId;

        public StackContentsRequest(string stackId)
        {
            _stackId = stackId;
        }

        public override async Task<Response<Objects.ArrayOfResults<Objects.StashMetadata>>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"stash/{_stackId}/contents");
        }
    }
}