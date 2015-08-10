namespace Twitty.Streaming
{
    public interface ISender<in T>
    {
        void Send(T data);
    }
}
