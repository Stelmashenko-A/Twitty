using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Twitty.Utility
{
    internal class ConversionUtility
    {
        internal static byte[] ReadStream(Stream responseStream)
        {
            byte[] data;
            var buffer = new byte[32768];
            using (var ms = new MemoryStream())
            {
                while (true)
                {
                    var read = responseStream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                    {
                        data = ms.ToArray();
                        break;
                    }
                    ms.Write(buffer.ToArray(), 0, read);
                }
            }
            return data;

        }
    }
}
