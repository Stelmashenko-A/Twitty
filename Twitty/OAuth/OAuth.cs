using System;
using System.IO;

namespace Twitty.OAuth
{
    class OAuth
    {
        public static GettingOAuthTokens GetRequestToken(string consumerKey, string consumerSecret,
            string callbackAddress)
        {
            var webRequestBuilder = new WebRequestBuilder(new Uri("https://api.twitter.com/oauth/request_token"), HTTPVerb.POST, new OAuthTokens { ConsumerKey = consumerKey, ConsumerSecret = consumerSecret });
            var result = string.Empty;
            var httpWebResponse = webRequestBuilder.Response;
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
            throw new NotImplementedException();
        }
    }
}
