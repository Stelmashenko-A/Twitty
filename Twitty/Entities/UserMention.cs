using System;
using System.Collections.Generic;

namespace Twitty.Entities
{
    class UserMention
    {
        public Int64 Id { get; set; }
        public String IdStr { get; set; }
        public List<int> Indices { get; set; }
        public String Name { get; set; }
        public String ScreenName { get; set; }
    }
}
