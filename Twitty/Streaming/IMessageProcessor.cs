namespace Twitty.Streaming
{
    public interface IMessageProcessor
    {
        void Proccess(string message);
    }
}
