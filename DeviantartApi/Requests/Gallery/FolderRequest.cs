using DeviantartApi.Attributes;
using System.Collections.Generic;

namespace DeviantartApi.Requests.Gallery
{
    public class FolderRequest : Collections.FolderRequest
    {
        protected override string FolderPath { get; set; } = "gallery";

        public FolderRequest(string folderId) : base(folderId)
        {
        }

        public enum SortMode
        {
            Popular,
            Newest
        }

        [Parameter("mode")]
        public SortMode? Mode { get; set; }

        protected override Dictionary<string, string> FillValues()
        {
            var values = base.FillValues();
            values.AddParameter(() => Mode);
            return values;
        }
    }
}
