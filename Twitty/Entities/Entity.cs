using System.Collections.Generic;

namespace Twitty.Entities
{
    public class Entity
    {
        public List<Hashtags> Hashtags { get; set; }
        public List<Media> Media { get; set; }
        public List<TwitterUrl> Urls { get; set; }
        public List<UserMention> UserMentions { get; set; }

    }
}
