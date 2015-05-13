using System.Globalization;
using Twitty.OAuth;
using Twitty.Options;
using Twitty.Tweets;

namespace Twitty.Commands
{
    internal sealed class DeleteStatusCommand : CommandToTwitter<Tweet>
    {

        public DeleteStatusCommand(OAuthTokens tokens, decimal id)
            : base(
                HttpVerb.Post,
                string.Format(CultureInfo.InvariantCulture, "https://api.twitter.com/1.1/statuses/destroy.json"),
                tokens,
                (TwitterOptions)null)
        {
            Id = id;
        }

        public decimal Id { get; set; }

        public override void Initialize()
        {
        }
    }
}
