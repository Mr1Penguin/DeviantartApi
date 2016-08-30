using System.Threading.Tasks;

namespace DeviantartApi.Requests.Collections
{
    public class FoldersRequest : PageableRequest<Objects.Folders<Objects.SubObjects.CollectonFolder>>
    {
        public bool LoadMature { get; set; }
        public string UserName { get; set; }
        public bool CalculateSize { get; set; }
        public bool ExtPreload { get; set; }

        public override async Task<Response<Objects.Folders<Objects.SubObjects.CollectonFolder>>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync("collections/folders?" +
                                                $"username={UserName}" +
                                                (Offset != null ? $"&offset={Offset}" : "") +
                                                (Limit != null ? $"&limit={Limit}" : "") +
                                                $"&calculate_size={CalculateSize.ToString().ToLower()}" +
                                                $"&ext_preload={ExtPreload.ToString().ToLower()}" +
                                                $"&mature_content={LoadMature.ToString().ToLower()}");
        }
    }
}
