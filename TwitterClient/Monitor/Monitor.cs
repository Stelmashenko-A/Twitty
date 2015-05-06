using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterClient.Monitor
{
    public class Monitor<T>:IMonitor<T>
    {
        private readonly List<IFilter<T>> _filters;
        private readonly IAddable<T> _database;

        public Monitor(List<IFilter<T>> filters, IAddable<T> database)
        {
            _filters = filters;
            _database = database;
        }

        private bool IsSkiped(T data)
        {
            //TODO create filtres
            //return _filters.All(filter => filter.IsValid(data));
            return true;
        }


        public async Task ProccessAsync(T data)
        {
            Func<T, bool> func = IsSkiped;
            var result = await Task.Run(()=>func(data));
            if (result)
            {
                _database.Add(data);
            }
        }
    }
}
