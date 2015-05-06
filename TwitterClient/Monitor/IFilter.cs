using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClient.Monitor
{
    public interface IFilter<in T>
    {
        bool IsValid(T item);
    }
}
