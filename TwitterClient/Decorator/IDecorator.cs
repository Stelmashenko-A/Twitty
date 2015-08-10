using System.Collections.Generic;

namespace TwitterClient.Decorator
{
    interface IDecorator<in TIn, out TOut> where TOut:IDecoratable<TIn>
    {
        TOut Decorate(TIn item);

        IEnumerable<TOut> Decorate(IEnumerable<TIn> items);
    }
}
