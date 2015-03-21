using Twitty.Account;
using Twitty.OAuth;

namespace Twitty.Kernel
{
    public class Account
    {
        public Account()
        {
            var tokens = new OAuthTokens();
            tokens.ConsumerKey = "p8EhMYTOxPcyoJAuJ0kABxITI";
            tokens.ConsumerSecret = "CfQN1xCgfCWBeFDIYx2WG1Jf4sFlByB5fxAl0VKMUfsolnby1n";
            tokens.AccessToken = "2765688547-vun5RgYHxZ28ru7MShpaDtMedZQX2DopGesRYEb";
            tokens.AccessTokenSecret = "hov1Q58KnL5g7ztMEd0KaY3R75Y8LrQBiIYdZPvw7pbCd"; 

            TwitterStatus.Update(tokens, "AZAZAZa");
        }
    }


}