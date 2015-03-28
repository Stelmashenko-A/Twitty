using Twitty.Account;
using Twitty.Kernel;

namespace Twitty.Commands
{
    class CommandPerfomer
    {
        public static Response<T> PerformCommand<T>(ICommand<T> command)
            where T : ITwitterObject
        {
            command.Initialize();
            return command.ExecuteCommand();
        }
    }
}
