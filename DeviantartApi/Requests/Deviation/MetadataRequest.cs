using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Deviation
{
    public class MetadataRequest : Request<Objects.DeviationMetadata>
    {
        public bool ExtSubmission { get; set; }
        public bool ExtCamera { get; set; }
        public bool ExtStats { get; set; }
        public bool ExtCollection { get; set; }

        public HashSet<string> DeviationIds = new HashSet<string>();

        public override async Task<Response<Objects.DeviationMetadata>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync("deviation/metadata?" +
                                                string.Join("&", DeviationIds.Select(x => "deviationids[]=" + x).ToList()) +
                                                "&ext_submission=" + ExtSubmission.ToString().ToLower() +
                                                "&ext_camera=" + ExtCamera.ToString().ToLower() +
                                                "&ext_stats=" + ExtStats.ToString().ToLower() +
                                                "&ext_collection=" + ExtCollection.ToString().ToLower());
        }
    }
}
