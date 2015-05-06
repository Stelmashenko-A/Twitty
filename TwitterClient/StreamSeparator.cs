using System.Threading;
using TweetSharp;

namespace TwitterClient
{
    public class StreamSeparator
    {

        public void Separate(TwitterService service, IAddable<TwitterStatus> statuses)
        {

            var block = new AutoResetEvent(false);

            service.StreamUser((streamEvent, response) =>
            {
                if (streamEvent is TwitterUserStreamEnd)
                {
                    block.Set();
                }

                if (response.StatusCode == 0)
                {
                    if (streamEvent is TwitterUserStreamStatus)
                    {
                        var tweet = ((TwitterUserStreamStatus) streamEvent).Status;
                        statuses.Add(tweet);
                    }

                }
            });


        }
    }
}
