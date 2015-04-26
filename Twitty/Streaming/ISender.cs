namespace Twitty.Streaming
{
    public interface ISender<T>
    {
         
        void Send(T data);
    }
}
