using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace Twitty.OAuth
{
    class OAuth
    {
        public static GettingOAuthTokens GetRequestToken(string consumerKey, string consumerSecret,
            string callbackAddress)
        {
            var webRequestBuilder = new WebRequestBuilder(new Uri("https://api.twitter.com/oauth/request_token"),
                HTTPVerb.POST, new OAuthTokens {ConsumerKey = consumerKey, ConsumerSecret = consumerSecret});
            var result = string.Empty;
            var httpWebResponse = webRequestBuilder.ExecutedRequest;
            var stream = httpWebResponse.GetResponseStream();
            if (stream != null)
            {
                result = new StreamReader(stream).ReadToEnd();
            }
            return new GettingOAuthTokens()
            {
                Token = ParseQuerystringParameter("oauth_token", result),
                TokenSecret = ParseQuerystringParameter("oauth_token_secret", result),
                VerificationString = ParseQuerystringParameter("oauth_verifier", result)
            };

        }

        private static string ParseQuerystringParameter(string parametrName, string data)
        {
            var expression = Regex.Match(data, string.Format(@"{0}=(?<value>[^&]+)", parametrName));

            return !expression.Success ? string.Empty : expression.Groups["value"].Value;
        }

        public static void GetOauthVerifier(GettingOAuthTokens tokens, Kernel.IDataReader dataReader)
        {
            var requestUrl = "http://api.twitter.com/oauth/authorize?oauth_token=" + tokens.Token;
            System.Diagnostics.Process.Start(requestUrl);
            dataReader.ShowDialog();
            tokens.VerificationString = dataReader.Data;

        }
    }
}
