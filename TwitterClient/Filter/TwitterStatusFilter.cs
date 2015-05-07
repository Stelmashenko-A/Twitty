using System.Collections.Generic;
using TweetSharp;

namespace TwitterClient.Filter
{
    abstract class TwitterTextFilter:IFilter<TwitterStatus>
    {
        protected SortedSet<string> _invalidParams = new SortedSet<string>();
        public abstract bool IsValid(TwitterStatus item);
    }
}
