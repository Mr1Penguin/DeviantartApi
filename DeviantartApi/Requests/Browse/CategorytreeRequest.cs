using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse
{
    public class CategorytreeRequest : Request<Objects.CategoryTree>
    {
        /// <summary>
        /// Default path: "/"
        /// </summary>
        public string Catpath { get; set; } = "/";

        public bool LoadMature { get; set; }

        public override async Task<Response<Objects.CategoryTree>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync("browse/categorytree?" +
                                                $"catpath={Catpath}" +
                                                $"&mature_content={LoadMature.ToString().ToLower()}");
        }
    }
}
