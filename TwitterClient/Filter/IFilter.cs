namespace TwitterClient.Filter
{
    public interface IFilter<in T>
    {
        bool IsValid(T item);
    }
}