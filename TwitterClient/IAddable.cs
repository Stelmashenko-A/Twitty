namespace TwitterClient
{
    public interface IAddable<in T>
    {
        void Add(T item);
    }
}
