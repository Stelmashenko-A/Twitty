using System;
using Twitty.Serialization;
using Twitty.Tweets;

namespace Twitty.Streaming
{
    public class MessageProcessor:IMessageProcessor
    {
        private ISender<Tweet> _sender;
        public MessageProcessor(ISender<Tweet> sender)
        {
            _sender = sender;
        }
        public void Proccess(string message)
        {
            var tweet = Serializer<Tweet>.Deserialize(message);
            _sender.Send(tweet);
            //Sender<Tweet>.SenderEventHandler(tweet);
        }
    }
}
