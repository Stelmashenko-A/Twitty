using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using TwitterClient.Filter;

namespace TwitterClient.Monitor
{
    [CollectionDataContract]
    public class Monitor<T>:IMonitor<T>
    {
        
        [DataMember]
        private readonly List<IFilter<T>> _filters;

        public IAddable<T> DataBase { get; set; }

        public Monitor() { }

        public Monitor(IAddable<T> database)
        {
            DataBase = database;
            _filters = new List<IFilter<T>>();
        }
        public Monitor(List<IFilter<T>> filters, IAddable<T> database)
        {
            _filters = filters;
            DataBase = database;
        }

        private bool IsSkiped(T data)
        {
            return _filters.All(filter => filter.IsValid(data));
        }

        public async Task ProccessAsync(T data)
        {
            Func<T, bool> func = IsSkiped;
            var result = await Task.Run(()=>func(data));
            if (result)
            {
                DataBase.Add(data);
            }
        }

        ~Monitor()
        {
            Stream testFileStream = File.Create("filters.Json");
            
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(testFileStream, _filters);
        }

        private List<IFilter<T>> getFilterFromFile()
        {
            BinaryFormatter deser = new BinaryFormatter();
            List<IFilter<T>> qwer;
            Stream stream = new FileStream("filters.Json", FileMode.Open);
            qwer = (List<IFilter<T>>)deser.Deserialize(stream);

            return qwer;

        }
    }
}
