using System;
using System.Collections.Generic;

namespace Twitty.Entities
{
    [SerializableAttribute]
    public class Media
    {
        public string DisplayUrl { get; set; }

        public string ExpandedUrl { get; set; }

        public long Id { get; set; }
       
        public string IdStr { get; set; }
        
        public List<int> Indices { get; set; }
        
        public string MediaUrl { get; set; }
        
        public string MediaUrlHtps { get; set; }
        
        public long SourceStatusId { get; set; }
        
        public string Type { get; set; }
        
        public string Url { get; set; }
    }
}
