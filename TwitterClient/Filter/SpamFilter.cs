using TweetSharp;

namespace TwitterClient.Filter
{
    class TextSpamFilter:TwitterTextFilter
    {
        public override bool IsValid(TwitterStatus item)
        {
            if (InvalidParams.Contains(item.Text))
            {
                return false;
            }

            InvalidParams.Add(item.Text);
            return true;
        }
    }
}
