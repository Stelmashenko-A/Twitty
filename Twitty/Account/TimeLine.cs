using Twitty.Commands;
using Twitty.OAuth;
using Twitty.Options;
using Twitty.Kernel;

namespace Twitty.Account
{
    public static class TimeLine
    {
        public static Response<StatusCollection> UserTimeline(OAuthTokens tokens, UserTimelineOptions options)
        {
            var command = new UserTimelineCommand(tokens, options);
            return CommandPerfomer.PerformCommand(command);
        }
    }
}
