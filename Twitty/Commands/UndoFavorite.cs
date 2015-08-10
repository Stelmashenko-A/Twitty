using System.Globalization;
using Twitty.OAuth;
using Twitty.Tweets;

namespace Twitty.Commands
{
    internal class UndoFavoriteCommand : CommandToTwitter<Tweet>
    {
        public UndoFavoriteCommand(OAuthTokens tokens, decimal id)
            : base(
                HttpVerb.Post,
                string.Format(CultureInfo.InvariantCulture, "https://api.twitter.com/1.1/favorites/destroy.json"),
                tokens,
                null)
        {
            Id = id;
        }

        public decimal Id { get; set; }

        public override void Initialize()
        {
            Parameters.Add("id", Id.ToString(CultureInfo.InvariantCulture));
        }
    }
}
