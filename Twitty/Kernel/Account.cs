using Twitty.Account;
using Twitty.OAuth;
using Twitty.Utility;

namespace Twitty.Kernel
{
    public class Account
    {
       OAuthTokens tokens = new OAuthTokens();

        public Account()
        {
            var gettingOAuthTokens = OAuth.OAuth.GetRequestToken("qwer",
                "qwer", null);
            OAuth.OAuth.GetOauthVerifier(gettingOAuthTokens, new InputBox());
            gettingOAuthTokens = OAuth.OAuth.GetAccessTokens("qwer", "qwert", gettingOAuthTokens.Token, gettingOAuthTokens.VerificationString);
            gettingOAuthTokens.Save("data.txt");
            tokens.AccessToken = gettingOAuthTokens.Token;
            tokens.AccessTokenSecret = gettingOAuthTokens.TokenSecret;
            tokens.ConsumerKey = "qwert";
            tokens.ConsumerSecret = "qwerty";
            TwitterStatus.Update(tokens, "twit");
        }
    }


}