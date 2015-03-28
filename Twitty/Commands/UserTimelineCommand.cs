using Twitty.OAuth;
using Twitty.Options;

namespace Twitty.Commands
{
    internal class UserTimelineCommand : PagedTimelineCommand
    {
        public UserTimelineCommand(OAuthTokens tokens, TwitterOptions options)
            : base(HTTPVerb.GET, "statuses/user_timeline.json", tokens, options)
        {
        }

        public override void Initialize()
        {
            var options = Options as UserTimelineOptions ?? new UserTimelineOptions();

            TimeLineOptions.Initialize(this, options);

            if (options.UserId > 0)
                Parameters.Add("user_id", options.UserId.ToString("#"));

            if (!string.IsNullOrEmpty(options.ScreenName))
                Parameters.Add("screen_name", options.ScreenName);
        }
    }
}
