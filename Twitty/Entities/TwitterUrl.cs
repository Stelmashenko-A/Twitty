using System;
using System.Collections.Generic;

namespace Twitty.Entities
{
    [SerializableAttribute]
    public class TwitterUrl
    {
        public string DisplayUrl { get; set; }
       
        public string ExpandedUrl { get; set; }
        
        public List<int> Indices { get; set; }
        
        public string UrlStr { get; set; }

    }
}
