using Newtonsoft.Json;

namespace Twitty.Streaming
{
    public class StreamSerializer<TOut, TGetter> where TGetter : IGetter<string>
    {
        private readonly TGetter _getter;

        private readonly ISender<TOut> _sender;

        public StreamSerializer(TGetter getter, ISender<TOut> sender)
        {
            _getter = getter;
            _sender = sender;
        }

        public static TOut Deserialize(string data)
        {
            return JsonConvert.DeserializeObject<TOut>(data);
        }

        public void Start()
        {
            while (true)
            {
                string data;
                if (_getter.TryGet(out data))
                {

                    _sender.Send(Deserialize(data));

                }
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}