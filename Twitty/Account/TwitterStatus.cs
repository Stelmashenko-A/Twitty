using System;
using Twitty.Commands;
using Twitty.Kernel;
using Twitty.OAuth;

namespace Twitty.Account
{
    internal class TwitterStatus : ITwitterObject
    {
        public static TwitterResponse<TwitterStatus> Update(OAuthTokens tokens, string text)
        {
            var command = new CommandForStatusUpdating(tokens, text);
            throw new NotImplementedException();
            return new TwitterResponse<TwitterStatus>();

        }

    }
}