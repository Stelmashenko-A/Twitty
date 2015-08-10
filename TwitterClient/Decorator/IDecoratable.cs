namespace TwitterClient.Decorator
{
    public interface IDecoratable<out T>
    {
        T Base { get; }
    }
}
