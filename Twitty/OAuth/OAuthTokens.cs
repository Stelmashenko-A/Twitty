namespace Twitty.OAuth
{
    public class OAuthTokens
    {
        public string ConsumerKey
        {
            get; set;
        }

        public string ConsumerSecret
        {
            get; set;
        }

        public string AccessToken
        {
            get; set;
        }

        public string AccessTokenSecret
        {
            get; set;
        }

        public bool IsIdentified()
        {
            return !string.IsNullOrEmpty(AccessToken) && !string.IsNullOrEmpty(AccessTokenSecret) &&
                   !string.IsNullOrEmpty(ConsumerKey) && !string.IsNullOrEmpty(ConsumerSecret);
        }
    }
}
