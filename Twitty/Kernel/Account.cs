using System.Security.Policy;
using Twitty.OAuth;
using Twitty.Utility;

namespace Twitty.Kernel
{
    public class Account
    {
       OAuthTokens tokens = new OAuthTokens();

        public Account()
        {
            var gettingOAuthTokens = OAuth.OAuth.GetRequestToken("myToken",
                "myTokeSecret", null);
            OAuth.OAuth.GetOauthVerifier(gettingOAuthTokens, new InputBox());
        }
    }


}