using Twitty.Account;
using Twitty.OAuth;

namespace Twitty.Commands
{
    class CommandForStatusUpdating:CommandToTwitter<TwitterStatus>
    {
        public string Text
        {
            get; set;
        }

        public CommandForStatusUpdating(OAuth.OAuthTokens tokens, string text)
            : base(HTTPVerb.POST, "https://api.twitter.com/1.1/statuses/update.json", tokens)
        {
            Text = text;
        }
    }
}
