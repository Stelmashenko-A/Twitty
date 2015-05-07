using TweetSharp;

namespace TwitterClient.Filter
{
    class TextSpamFilter:TwitterTextFilter
    {
        public override bool IsValid(TwitterStatus item)
        {
            if (_invalidParams.Contains(item.Text))
            {
                return false;
            }
            _invalidParams.Add(item.Text);
            return true;
        }
    }
}
