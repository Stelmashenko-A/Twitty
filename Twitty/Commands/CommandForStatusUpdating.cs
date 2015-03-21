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

        public CommandForStatusUpdating(OAuthTokens tokens, string text)
            : base(HTTPVerb.POST, "https://api.twitter.com/1.1/statuses/update.json", tokens, null)
        {
            Text = text;
        }

        public override void Initialize()
        {
            Parameters.Add("status", Text);
        }
    }
}
