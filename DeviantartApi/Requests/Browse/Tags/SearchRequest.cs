using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse.Tags
{
    public class SearchRequest : Request<Objects.TagsSearchResults>
    {
        public string Tag { get; set; }

        public override async Task<Response<Objects.TagsSearchResults>> ExecuteAsync()
        {
            return await ExecuteDefaultAsync("browse/tags/search?" + $"tag_name={Tag}");
        }
    }
}
