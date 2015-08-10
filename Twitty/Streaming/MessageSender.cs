using System.Collections.Concurrent;

namespace Twitty.Streaming
{
    public class MessageSender<T>:ISender<T>
    {
        readonly ConcurrentQueue<T> _messageQueue;

        public MessageSender(ConcurrentQueue<T> messageQueue)
        {
            _messageQueue = messageQueue;
        }

        public void Send(T data)
        {
            _messageQueue.Enqueue(data);
        }
    }
}
