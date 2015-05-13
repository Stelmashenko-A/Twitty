using Twitty.OAuth;
using Twitty.Options;
using Twitty.Tweets;

namespace Twitty.Commands
{
    internal class CommandForStatusUpdating : CommandToTwitter<Tweet>
    {
        public string Text { get; set; }

        public CommandForStatusUpdating(OAuthTokens tokens, string text)
            : base(HttpVerb.Post, "https://api.twitter.com/1.1/statuses/update.json", tokens, (TwitterOptions) null)
        {
            Text = text;
        }

        public override void Initialize()
        {
            Parameters.Add("status", Text);
        }
    }
}
