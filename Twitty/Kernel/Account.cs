using System.Security.Policy;
using Twitty.OAuth;

namespace Twitty.Kernel
{
    public class Account
    {
       OAuthTokens tokens = new OAuthTokens();

        public Account()
        {
            var gettingOAuthTokens = OAuth.OAuth.GetRequestToken("myKey",
                "mySecret",null);
        }
    }


}