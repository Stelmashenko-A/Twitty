namespace TwitterAnalyzer
{
    public interface IGetter<T>
    {
        bool TryGet(out T data);
    }
}
