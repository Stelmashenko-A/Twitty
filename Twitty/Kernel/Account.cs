using Twitty.OAuth;
using Twitty.Utility;

namespace Twitty.Kernel
{
    public class Account
    {
       OAuthTokens tokens = new OAuthTokens();

        public Account()
        {
            var gettingOAuthTokens = OAuth.OAuth.GetRequestToken("khfn1j8qJA0Bp5492LOQOZXWD",
                "T7ptoDPnItslpXTDoDNmjcL3CMEBX4JwNoARGxlBGqir2jp25R", null);
            OAuth.OAuth.GetOauthVerifier(gettingOAuthTokens, new InputBox());
            gettingOAuthTokens = OAuth.OAuth.GetAccessTokens("khfn1j8qJA0Bp5492LOQOZXWD", "T7ptoDPnItslpXTDoDNmjcL3CMEBX4JwNoARGxlBGqir2jp25R", gettingOAuthTokens.Token, gettingOAuthTokens.VerificationString);
            gettingOAuthTokens.Save("data.txt");
        }
    }


}