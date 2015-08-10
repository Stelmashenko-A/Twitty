using System;
using System.Collections.Generic;

namespace Twitty.Entities
{
    [SerializableAttribute]
    public class UserMention
    {
        public long Id { get; set; }
        
        public string IdStr { get; set; }
        
        public List<int> Indices { get; set; }
        
        public string Name { get; set; }
        
        public string ScreenName { get; set; }
    }
}
