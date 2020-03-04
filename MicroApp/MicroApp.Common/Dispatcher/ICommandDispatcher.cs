using MicroApp.Common.Messages;
using System.Threading.Tasks;

namespace MicroApp.Common.Dispatcher
{
    public interface ICommandDispatcher
    {
        Task SendAsync<T>(T command) where T : ICommand;
    }
}
