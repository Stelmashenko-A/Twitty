namespace Twitty.Streaming
{
    public interface IGetter<T>
    {
        bool TryGet(out T data);
    }
}
