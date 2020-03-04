using MicroApp.Common.Messages;
using MicroApp.Common.Types;
using System.Threading.Tasks;

namespace MicroApp.Common.Dispatcher
{
    public interface IDispatcher
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}
