using System.Threading;
using TweetSharp;

namespace TwitterClient
{
    public class StreamSeparator
    {
        public void Separate(TwitterService service, IAddableAsync<TwitterStatus> statuses)
        {

            var block = new AutoResetEvent(false);

            service.StreamUser((streamEvent, response) =>
            {
                if (streamEvent is TwitterUserStreamEnd)
                {
                    block.Set();
                }

                if (response.StatusCode != 0) return;
                if (!(streamEvent is TwitterUserStreamStatus)) return;
                var tweet = ((TwitterUserStreamStatus) streamEvent).Status;
                statuses.AddAsync(tweet);
            });
        }
    }
}
