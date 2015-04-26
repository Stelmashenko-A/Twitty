using System;
using System.Collections.Generic;

namespace Twitty.Entities
{
    [SerializableAttribute]
    public class TwitterUrl
    {
        public String DisplayUrl { get; set; }
        public String ExpandedUrl { get; set; }
        public List<int> Indices { get; set; }
        public String UrlStr { get; set; }

    }
}
