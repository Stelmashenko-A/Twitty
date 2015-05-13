using System.Collections.Generic;
using System.Linq;
using TweetSharp;
using Twitty.OAuth;

namespace TwitterClient
{
    public sealed class TwitterClient:TwitterService
    {
        TwitterService _twitterService = new TwitterService();
        private OAuthTokens _currentAuthTokens = new OAuthTokens();

        private TwitterUser _currentUser;

        public TwitterClient(string consumerKey, string consumerSecret) : base(consumerKey, consumerSecret)
        {
            _currentAuthTokens.ConsumerKey = consumerKey;
            _currentAuthTokens.ConsumerSecret = consumerSecret;
        }
        public override void AuthenticateWith(string token, string tokenSecret)
        {
            base.AuthenticateWith(token, tokenSecret);
            _currentAuthTokens.AccessToken = token;
            _currentAuthTokens.AccessTokenSecret = tokenSecret;
            _currentUser = GetUserProfile(new GetUserProfileOptions());
        }

        public override TwitterStatus DeleteTweet(DeleteTweetOptions options)
        {
            Twitty.Tweets.Tweet.Delete(_currentAuthTokens, options.Id);
            return base.DeleteTweet(options);
        }

        public void UndoFavourite(FavoriteTweetOptions options)
        {
            Twitty.Tweets.Tweet.UndoFavourite(_currentAuthTokens, options.Id);
        }

        public IEnumerable<TwitterStatus> FullListTweetsOnUserTimeline()
        {
            var result = new List<TwitterStatus>();
            int page = 0;
            do
            {
                var options = new ListTweetsOnUserTimelineOptions() { ScreenName = _currentUser.ScreenName, Count = 200 };
                page++;
                if (page > 1)
                    options.MaxId = result.Last().Id-1;

                var res = (List<TwitterStatus>)ListTweetsOnUserTimeline(options);
                if (res == null || res.Count == 0)
                    break;
                result.AddRange(res);
            } while (result.Count < 3200 && result.Count < _currentUser.StatusesCount);
            return result;
        }


    }
}
