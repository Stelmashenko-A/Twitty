using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Twitty.Kernel
{
    public abstract class TwitterCollection<T> : Collection<T>
        where T : class
    {
        private Dictionary<string, string> Info
        {
            get; set;
        }
    }
}
