using TweetSharp;

namespace TwitterClient.Decorator
{
    public class DecoratedTwitterStatus : IDecoratable<TwitterStatus>
    {
        public TwitterStatus Base { get; private set; }

        public DecoratedTwitterStatus(TwitterStatus twitterStatus)
        {
            Base = twitterStatus;
            IsRetweted = false;
            MyTweetId = -1;
        }

        public bool IsRetweted { get; internal set; }

        public long MyTweetId { get; internal set; }
    }
}