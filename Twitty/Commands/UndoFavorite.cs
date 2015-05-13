using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitty.OAuth;
using Twitty.Options;
using Twitty.Tweets;

namespace Twitty.Commands
{
    class UndoFavoriteCommand : CommandToTwitter<Tweet>
    {
        public UndoFavoriteCommand(OAuthTokens tokens, decimal id)
            : base(
                HttpVerb.Post,
                string.Format(CultureInfo.InvariantCulture, "https://api.twitter.com/1.1/favorites/destroy.json"),
                tokens,
                (TwitterOptions)null)
        {
            Id = id;
        }

        public decimal Id { get; set; }

        public override void Initialize()
        {
            Parameters.Add("id",Id.ToString(CultureInfo.InvariantCulture));
        }
    }
}
