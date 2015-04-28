using Twitty.Serialization;
using Twitty.Tweets;

namespace Twitty.Streaming
{
    public class MessageProcessor:IMessageProcessor
    {
        public ISender<Tweet> Sender1 { get; private set; }

        public MessageProcessor(ISender<Tweet> sender)
        {
            Sender1 = sender;
        }
        public void Proccess(string message)
        {
           
                var tweet = Serializer<Tweet>.Deserialize(message);
                Sender<Tweet>.SenderEventHandler(tweet);
           
            
            //_sender.Send(tweet);

            
        }
        //public delegate void CallbackEvent(Tweet data);
        //public CallbackEvent SenderEventHandler;
    }
}
