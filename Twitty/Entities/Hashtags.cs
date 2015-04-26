using System;
using System.Collections.Generic;

namespace Twitty.Entities
{
    [SerializableAttribute]
    public class Hashtags
    {
        public List<int> Indices { get; set; }
        public String Text { get; set; }
    }
}
