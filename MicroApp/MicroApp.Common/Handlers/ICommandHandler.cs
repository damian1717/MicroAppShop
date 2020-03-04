using MicroApp.Common.Messages;
using MicroApp.Common.RabbitMq;
using System.Threading.Tasks;

namespace MicroApp.Common.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, ICorrelationContext context);
    }
}