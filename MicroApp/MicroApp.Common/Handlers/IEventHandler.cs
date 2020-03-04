using MicroApp.Common.Messages;
using MicroApp.Common.RabbitMq;
using System.Threading.Tasks;

namespace MicroApp.Common.Handlers
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event, ICorrelationContext context);
    }
}