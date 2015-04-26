using System;

namespace Twitty.Entities
{
    [Serializable]
    class Sizes
    {
        public Size Thumb { get; set; }
        public Size Large { get; set; }
        public Size Medium { get; set; }
        public Size Small { get; set; }
    }
}
