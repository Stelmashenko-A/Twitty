using Twitty.OAuth;
using Twitty.Utility;

namespace Twitty.Kernel
{
    public class Account
    {
       OAuthTokens tokens = new OAuthTokens();

        public Account()
        {
            var gettingOAuthTokens = OAuth.OAuth.GetRequestToken("consumerKey",
                "consumerSecret", null);
            OAuth.OAuth.GetOauthVerifier(gettingOAuthTokens, new InputBox());
            gettingOAuthTokens = OAuth.OAuth.GetAccessTokens("consumerKey", "consumerSecret", gettingOAuthTokens.Token, gettingOAuthTokens.VerificationString);
            gettingOAuthTokens.Save("data.txt");
        }
    }


}