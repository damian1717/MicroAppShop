using Autofac;
using MicroApp.Common.Handlers;
using MicroApp.Common.Messages;
using MicroApp.Common.RabbitMq;
using System.Threading.Tasks;

namespace MicroApp.Common.Dispatcher
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task SendAsync<T>(T command) where T : ICommand
            => await _context.Resolve<ICommandHandler<T>>().HandleAsync(command, CorrelationContext.Empty);
    }
}
