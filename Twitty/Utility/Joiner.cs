using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitty.Utility
{
    public static class Joiner
    {
        public static string Join(List<string> data, string separator)
        {
            if (data == null || data.Count == 0)
            {
                return string.Empty;
            }
            StringBuilder stringBuilder = new StringBuilder("");
            stringBuilder.Append(data[0]);
            for (int i = 1; i < data.Count; i++)
            {
                stringBuilder.Append(separator);
                stringBuilder.Append(data[i]);
            }
            return stringBuilder.ToString();
        }
    }
}
