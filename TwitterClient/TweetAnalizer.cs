using TweetSharp;

namespace TwitterClient
{
    static class TweetAnalizer
    {
        public static bool IsRetweet(TwitterStatus item)
        {
            return item.RetweetedStatus != null;
        }
    }
}
