using Twitty.Account;
using Twitty.OAuth;
using Twitty.Options;

namespace Twitty.Kernel
{
    public class Account
    {
        public Account()
        {
            var tokens = new OAuthTokens();
            tokens.ConsumerKey = "";
            tokens.ConsumerSecret = "";
            tokens.AccessToken = "";
            tokens.AccessTokenSecret = ""; 

            Tweet.Update(tokens, "AZAZAZa");
            var options = new UserTimelineOptions()
            {
                ScreenName = "__BuS_TeR__",
                UserId = 2765688547,
                IncludeRetweets = false,
                Count = 10,
            };
            var srt = TimeLine.UserTimeline(tokens, options);       
        }
    }


}