using System.Collections.Generic;
using Twitty.Account;
using Twitty.Kernel;

namespace Twitty.Commands
{
    public interface ICommand<T>
        where T : ITwitterObject
    {
        Dictionary<string, object> Parameters { get; }
        
        void Initialize();

        Response<T> ExecuteCommand();

    }
}
