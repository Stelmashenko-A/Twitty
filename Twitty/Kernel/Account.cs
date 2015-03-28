using Twitty.Account;
using Twitty.OAuth;

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

            Status.Update(tokens, "AZAZAZa");
        }
    }


}