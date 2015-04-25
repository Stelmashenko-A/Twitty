using Twitty.Serialization;
using Twitty.Tweets;

namespace Twitty.Streaming
{
    public class MessageProcessor:IMessageProcessor
    {
        public void Proccess(string message)
        {
            var tweet = Serializer<Tweet>.Deserialize(message);
            Sender<Tweet>.SenderEventHandler(tweet);
        }
    }
}
