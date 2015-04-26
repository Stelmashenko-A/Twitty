using System;
using System.Collections.Generic;

namespace Twitty.Entities
{
    [SerializableAttribute]
    public class Media
    {
        public String DisplayUrl { get; set; }
        public String ExpandedUrl { get; set; }
        public Int64 Id { get; set; }
        public String IdStr { get; set; }
        public List<int> Indices { get; set; }
        public String MediaUrl { get; set; }
        public String MediaUrlHtps { get; set; }
        //public Size Sizes{get;set;}
        public Int64 SourceStatusId { get; set; }
        public String Type { get; set; }
        public String Url { get; set; }
 
    }
}
