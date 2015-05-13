using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterClient.Monitor;

namespace TwitterClient.Decorator
{
    public abstract class Decorator<TIn, TOut> : IAddableAsync<TIn>, IDecorator<TIn, TOut>
        where TOut : IDecoratable<TIn>
    {
        private readonly IMonitor<TOut> _endPoint;

        protected Decorator(IMonitor<TOut> endPoint)
        {
            _endPoint = endPoint;
        }

        public abstract TOut Decorate(TIn item);

        public IEnumerable<TOut> Decorate(IEnumerable<TIn> items)
        {
            return items.Select(Decorate).ToList();
        }

        public async Task AddAsync(TIn item)
        {
            await _endPoint.ProccessAsync(Decorate(item));
        }
    }
}
