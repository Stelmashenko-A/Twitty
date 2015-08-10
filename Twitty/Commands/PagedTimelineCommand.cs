using System.Globalization;
using Twitty.Kernel;
using Twitty.OAuth;
using Twitty.Options;

namespace Twitty.Commands
{
    internal abstract class PagedTimelineCommand : CommandToTwitter<StatusCollection>
    {
        protected PagedTimelineCommand(HttpVerb method, string endPoint, OAuthTokens tokens, TwitterOptions options)
            : base(method, endPoint, tokens, options)
        {
        }

        public override void Initialize()
        {
            Parameters.Add("include_entities", "true");

            var options = Options as TimeLineOptions;

            if (options == null)
            {
                Parameters.Add("page", "1");

                return;
            }
            if (options.SinceStatusId > 0)
                Parameters.Add("since_id", options.SinceStatusId.ToString("#"));

            if (options.MaxStatusId > 0)
                Parameters.Add("max_id", options.MaxStatusId.ToString("#"));

            if (options.Count > 0)
                Parameters.Add("count", options.Count.ToString(CultureInfo.InvariantCulture));

            if (options.IncludeRetweets)
                Parameters.Add("include_rts", "true");

            Parameters.Add("page", options.Page > 0 ? options.Page.ToString(CultureInfo.InvariantCulture) : "1");
        }
    }
}
