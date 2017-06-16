using DeviantartApi.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Requests.Browse
{
    public abstract class BrowseRequest : PageableRequest<Objects.Browse>
    {
        public enum UserExpand
        {
            Watch
        }

        [Parameter("user")]
        [Expands]
        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();

        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        /// <summary>
        /// Default path: "/"
        /// </summary>
        [Parameter("category_path")]
        public string CategoryPath { get; set; } = "/";
    }
}
