using Twitty.Account;
using Twitty.Kernel;

namespace Twitty.Tweets
{
    class StatusCollection : TwitterCollection<TwitterStatus>, ITwitterObject
    {
        public int PageNumber
        {
            get; set;
        }
    }
}
