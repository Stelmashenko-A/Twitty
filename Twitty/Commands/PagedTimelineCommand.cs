using Twitty.Account;
using Twitty.Kernel;
using Twitty.OAuth;
using Twitty.Options;

namespace Twitty.Commands
{
    internal abstract class PagedTimelineCommand : CommandToTwitter<Status>, ITwitterObject
    {
        protected PagedTimelineCommand(HTTPVerb method, string endPoint, OAuthTokens tokens, TwitterOptions options)
            : base(method, endPoint, tokens, options)
        {
        }
    }
}
