using Twitty.Account;
using Twitty.OAuth;

namespace Twitty.Kernel
{
    public class Account
    {
        public Account()
        {
            var tokens = new OAuthTokens();
            tokens.ConsumerKey = "asdf";
            tokens.ConsumerSecret = "asdf";
            tokens.AccessToken = "asdf";
            tokens.AccessTokenSecret = "asdf"; 

            TwitterStatus.Update(tokens, "Status has been updated through the API");
        }
    }


}