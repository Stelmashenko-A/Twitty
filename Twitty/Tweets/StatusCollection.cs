using Twitty.Kernel;

namespace Twitty.Tweets
{
    class StatusCollection : TwitterCollection<Tweet>, ITwitterObject
    {
        public int PageNumber
        {
            get; set;
        }
    }
}
