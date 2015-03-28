using Twitty.Account;
using Twitty.OAuth;
using Twitty.Options;

namespace Twitty.Commands
{
    class CommandForStatusUpdating:CommandToTwitter<Status>
    {
        public string Text
        {
            get; set;
        }

        public CommandForStatusUpdating(OAuthTokens tokens, string text)
            : base(HTTPVerb.POST, "https://api.twitter.com/1.1/statuses/update.json", tokens, (TwitterOptions) null)
        {
            Text = text;
        }

        public override void Initialize()
        {
            Parameters.Add("status", Text);
        }
    }
}
