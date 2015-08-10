using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TweetSharp;
using TwitterClient.Decorator;

namespace TwitterClient.Filter
{
    [Serializable]
    [DataContract]
    public abstract class TwitterTextFilter : IFilter<DecoratedTwitterStatus>
    {
        [DataMember]
        protected SortedSet<string> InvalidParams = new SortedSet<string>();

        public abstract bool IsValid(DecoratedTwitterStatus item);
    }
}
