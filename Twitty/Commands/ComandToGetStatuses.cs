using System;
using Twitty.OAuth;
using Twitty.Tweets;

namespace Twitty.Commands
{
    class ComandToGetStatuses : CommandToTwitter<StatusCollection>
    {
        public ComandToGetStatuses(HTTPVerb method, string endPoint, OAuthTokens tokens, byte[] responseData) : base(method, endPoint, tokens, responseData)
        {
        }
        public override void Initialize()
        {
            //Parameters.Add("user_id",)
            throw new NotImplementedException();
        }
    }
}
