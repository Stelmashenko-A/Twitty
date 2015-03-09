using Twitty.OAuth;

namespace Twitty.Account
{
    internal class TwitterResponse<T>
    {
        public T ResponseObject { get; set; }
        public string RequestUrl { get; set; }
        public string Content { get; set; }
        public OAuthTokens Tokens { get; set; }

    }
}