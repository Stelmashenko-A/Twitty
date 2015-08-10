using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TweetSharp;
using TwitterClient.Decorator;

namespace TwitterClient.Filter
{
    [Serializable]
    [DataContract]
    public class UserRetweetFilter : RewteetFilter
    {
        [DataMember]
        private readonly SortedSet<long> _usersId = new SortedSet<long>();

        public new bool IsValid(DecoratedTwitterStatus item)
        {
            return !_usersId.Contains(item.Base.Id) || base.IsValid(item);
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
