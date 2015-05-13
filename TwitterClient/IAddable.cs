using System.Collections.Generic;

namespace TwitterClient
{
    public interface IAddable<in T>
    {
        void Add(T item);

        void AddRange(IEnumerable<T> item);
    }
}
