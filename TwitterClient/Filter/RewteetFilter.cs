using TweetSharp;

namespace TwitterClient.Filter
{
    class RewteetFilter:IFilter<TwitterStatus>
    {
        public bool IsValid(TwitterStatus item)
        {
            return item.RetweetedStatus == null;
        }
    }
}
