using System;
using System.Collections.Generic;
using TweetSharp;

namespace TwitterClient.Users
{
    class TwitterGroup:List<TwitterUser>
    {
        public TwitterGroup()
        {
        }

        public TwitterGroup(List<TwitterUser> users)
        {
            if (users == null) throw new ArgumentNullException();
            AddRange(users);
        }

        public new void Add(TwitterUser user)
        {
            if (user == null) throw new ArgumentNullException();
            if (!Contains(user))
            {
                base.Add(user);
            }
        }

        public new void AddRange(IEnumerable<TwitterUser> users)
        {
            if (users == null) throw new ArgumentNullException();
            foreach (var variable in users)
            {
                Add(variable);
            }
        }
    }
}
