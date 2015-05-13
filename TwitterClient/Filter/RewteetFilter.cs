using System;
using TweetSharp;
using TwitterClient.Decorator;

namespace TwitterClient.Filter
{
    [Serializable]
    public class RewteetFilter : IFilter<DecoratedTwitterStatus>
    {
        public bool IsValid(DecoratedTwitterStatus item)
        {
            return item.Base.RetweetedStatus == null;
        }
    }
}
