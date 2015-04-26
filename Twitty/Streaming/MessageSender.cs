using System.Messaging;
using Twitty.Tweets;

namespace Twitty.Streaming
{
    public class MessageSender:ISender<Tweet>
    {
        MessageQueue messageQueue;

        public MessageSender(string messageQueueName)
        {
            messageQueue = MessageQueue.Exists(@messageQueueName)
                ? new MessageQueue(@messageQueueName)
                : MessageQueue.Create(@messageQueueName);
        }

        public void Send(Tweet data)
        {
            Message message = new Message(data, new BinaryMessageFormatter());
            messageQueue.Send(message);
        }
    }
}
