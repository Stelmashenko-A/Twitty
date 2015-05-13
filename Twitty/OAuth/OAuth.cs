using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using Twitty.Kernel;

namespace Twitty.OAuth
{
    internal class OAuth
    {
        public static GettingOAuthTokens GetRequestToken(string consumerKey, string consumerSecret,
            string callbackAddress)
        {
            var webRequestBuilder = new WebRequestBuilder(new Uri("https://api.twitter.com/oauth/request_token"),
                HttpVerb.Post, new OAuthTokens {ConsumerKey = consumerKey, ConsumerSecret = consumerSecret});
            var result = string.Empty;
            var httpWebResponse = webRequestBuilder.ExecuteRequest();
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

        public static void GetOauthVerifier(GettingOAuthTokens tokens, IDataReader dataReader)
        {
            var requestUrl = "http://api.twitter.com/oauth/authorize?oauth_token=" + tokens.Token;
            Process.Start(requestUrl);
            dataReader.Show();
            tokens.VerificationString = dataReader.Data;

        }

        public static GettingOAuthTokens GetAccessTokens(string consumerKey, string consumerSecret, string requestToken,
            string verifier)
        {
            var webRequestBuilder = new WebRequestBuilder(new Uri("https://api.twitter.com/oauth/access_token"),
                HttpVerb.Post, new OAuthTokens {ConsumerKey = consumerKey, ConsumerSecret = consumerSecret});
            webRequestBuilder.Parameters.Add("oauth_verifier", verifier);
            webRequestBuilder.Parameters.Add("oauth_token", requestToken);

            var webResponse = webRequestBuilder.ExecuteRequest();
            // ReSharper disable once AssignNullToNotNullAttribute
            var twitterAnswer = new StreamReader(stream: webResponse.GetResponseStream()).ReadToEnd();
            var response = new GettingOAuthTokens
            {
                Token = Regex.Match(twitterAnswer, @"oauth_token=([^&]+)").Groups[1].Value,
                TokenSecret = Regex.Match(twitterAnswer, @"oauth_token_secret=([^&]+)").Groups[1].Value,
                UserId =
                    long.Parse(Regex.Match(twitterAnswer, @"user_id=([^&]+)").Groups[1].Value,
                        CultureInfo.CurrentCulture),
                ScreenName = Regex.Match(twitterAnswer, @"screen_name=([^&]+)").Groups[1].Value
            };
            return response;
        }
    }
}
