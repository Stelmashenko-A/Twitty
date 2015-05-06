using System.Collections.Concurrent;

namespace Twitty.Streaming
{
    public class Getter<T> : IGetter<T> where T : class
    {
        private readonly ConcurrentQueue<T> _messageQueue;

        public Getter(ConcurrentQueue<T> messageQueue)
        {
            _messageQueue = messageQueue;
        }

        public bool TryGet(out T data)
        {
            if (_messageQueue.TryDequeue(out data))
                return true;
            data = null;
            return false;
        }
    }
}
