using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Twitty.Kernel;

namespace Twitty.Serialization
{
    public static class Serializer<T> where T : ITwitterObject
    {
        public delegate T DeserializationHandler(JObject value);

        public static T Deseialize(byte[] data)
        {
            return Deserialize(Encoding.UTF8.GetString(data, 0, data.Length));
        }

        public static T Deserialize(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
