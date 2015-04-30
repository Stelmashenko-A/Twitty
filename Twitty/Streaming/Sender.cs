namespace Twitty.Streaming
{
    public static class Sender<T>
    {
        public delegate void CallbackEvent(T data);
        public static event CallbackEvent SenderEventHandler;
    }
}
