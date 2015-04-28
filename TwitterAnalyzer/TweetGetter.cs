using System;
using System.Messaging;
using Twitty.Tweets;

namespace TwitterAnalyzer
{
    public class TweetGetter:IGetter<Tweet>
    {
        private readonly MessageQueue _messageQueue;
        public TweetGetter(string messageQueueName)
        {
            _messageQueue = MessageQueue.Exists(@messageQueueName)
                ? new MessageQueue(@messageQueueName)
                : MessageQueue.Create(@messageQueueName);
        }

        public bool TryGet(out Tweet data)
        {

            _messageQueue.Formatter = new BinaryMessageFormatter();
            Message myMessage = _messageQueue.Receive();
            data = null;
            if (myMessage != null) data = (Tweet) myMessage.Body;
            if (data == null)
                return false;
            return true;
        }
    }
}
