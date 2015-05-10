using TweetSharp;
using TwitterClient.Monitor;

namespace TwitterClient.Decorator
{
    public class TwitterStatusDecorator : Decorator<TwitterStatus, DecoratedTwitterStatus>
    {
        private readonly UserProfile _userProfile;

        public TwitterStatusDecorator(IMonitor<DecoratedTwitterStatus> endPoint, UserProfile userProfile)
            : base(endPoint)
        {
            _userProfile = userProfile;
        }

        public override DecoratedTwitterStatus Decorate(TwitterStatus item)
        {
            if (item.Author.ScreenName == _userProfile.TwitterUser.ScreenName && item.RetweetedStatus != null)
            {
                _userProfile.AuthenticatedUserRetweets.Add(item.RetweetedStatus.Id, item.Id);
            }
            var decoratedTwitterStatus = new DecoratedTwitterStatus(item);
            if (item.RetweetedStatus != null &&
                _userProfile.AuthenticatedUserRetweets.ContainsKey(item.RetweetedStatus.Id))
            {
                decoratedTwitterStatus.IsRetweted = true;
                decoratedTwitterStatus.MyTweetId = _userProfile.AuthenticatedUserRetweets[item.RetweetedStatus.Id];
                return decoratedTwitterStatus;
            }
            if (!_userProfile.AuthenticatedUserRetweets.ContainsKey(item.Id)) return decoratedTwitterStatus;
            decoratedTwitterStatus.IsRetweted = true;

            decoratedTwitterStatus.MyTweetId = _userProfile.AuthenticatedUserRetweets[item.Id];
            return decoratedTwitterStatus;
        }
    }
}

