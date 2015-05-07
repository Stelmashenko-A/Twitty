using System.Collections.Generic;
using TweetSharp;

namespace TwitterClient.Filter
{
    internal class UserRetweetFilter : RewteetFilter
    {
        private readonly SortedSet<long> _usersId = new SortedSet<long>();

        public new bool IsValid(TwitterStatus item)
        {
            return !_usersId.Contains(item.Id) || base.IsValid(item);
        }

        public bool BlockedUser(TwitterUser item)
        {
            return _usersId.Add(item.Id);
        }

        public bool UnBlockUser(TwitterUser item)
        {
            return _usersId.Remove(item.Id);
        }
    }
}
