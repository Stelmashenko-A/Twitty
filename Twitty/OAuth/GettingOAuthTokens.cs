
using System.IO;

namespace Twitty.OAuth
{
    public class GettingOAuthTokens
    {
        public string Token { get; set; }

        public string TokenSecret { get; set; }

        public string ScreenName { get; set; }

        public decimal UserId { get; set; }

        public string VerificationString { get; set; }

        public void Save(string fileName)
        {
            var sw = new StreamWriter(fileName);
            sw.WriteLine(Token);
            sw.WriteLine(TokenSecret);
            sw.WriteLine(ScreenName);
            sw.WriteLine(UserId);
            sw.WriteLine(VerificationString);
            sw.Close();
        }
    }
}
