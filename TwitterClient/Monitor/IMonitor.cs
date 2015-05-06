using System.Threading.Tasks;

namespace TwitterClient.Monitor
{
    public interface IMonitor<in T>
    {
        Task ProccessAsync(T data);
    }
}
