using Twitty.Commands;
using Twitty.Kernel;

namespace Twitty.Options
{
    public class TimeLineOptions : TwitterOptions
    {
        public decimal SinceStatusId { get; set; }

        public decimal MaxStatusId { get; set; }

        public int Count { get; set; }

        public int Page { get; set; }

        public bool SkipUser { get; set; }

        public bool IncludeRetweets { get; set; }

        internal static void Initialize<T>(CommandToTwitter<T> command, TimeLineOptions options)
            where T : ITwitterObject
        {
            command.Parameters.Add("include_entities", "true");

            if (options == null)
                options = new TimeLineOptions();

            if (options.Count > 0)
                command.Parameters.Add("count", options.Count.ToString());

            if (options.IncludeRetweets)
                command.Parameters.Add("include_rts", "true");

            if (options.MaxStatusId > 0)
                command.Parameters.Add("max_id", options.MaxStatusId.ToString("#"));

            command.Parameters.Add("page", options.Page > 0 ? options.Page.ToString() : "1");

            if (options.SinceStatusId > 0)
                command.Parameters.Add("since_id", options.SinceStatusId.ToString("#"));

            if (options.SkipUser)
                command.Parameters.Add("trim_user", "true");
        }
    }
}
