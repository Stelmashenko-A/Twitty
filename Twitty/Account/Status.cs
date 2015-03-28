using Twitty.Commands;
using Twitty.Kernel;
using Twitty.OAuth;

namespace Twitty.Account
{
    internal class Status : ITwitterObject
    {
        public static Response<Status> Update(OAuthTokens tokens, string text)
        {
            var command = new CommandForStatusUpdating(tokens, text);
            return CommandPerfomer.PerformCommand(command);
        }
    }
}