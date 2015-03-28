using Twitty.Account;
using Twitty.Kernel;

namespace Twitty.Tweets
{
    class StatusCollection : TwitterCollection<Status>, ITwitterObject
    {
        public int PageNumber
        {
            get; set;
        }
    }
}
