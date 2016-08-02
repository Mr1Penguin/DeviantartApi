using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse
{
    /// <summary>
    /// Class for getting categorytree. Default path: "/".
    /// </summary>
    public class CategorytreeRequest : Request<Objects.CategoryTree>
    {
        public string Catpath { get; set; } = "/";
        public bool LoadMature { get; set; }

        public override async Task<Response<Objects.CategoryTree>> ExecuteAsync()
        {
            return await ExecuteDefaultAsync("browse/categorytree?" + 
                                             $"catpath={Catpath}" + 
                                             $"&mature_content={LoadMature.ToString().ToLower()}");
        }
    }
}
