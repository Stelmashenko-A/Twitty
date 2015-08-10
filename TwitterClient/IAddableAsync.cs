using System.Threading.Tasks;

namespace TwitterClient
{
    public interface IAddableAsync<in T>
    {
        Task AddAsync(T item);
    }
}

