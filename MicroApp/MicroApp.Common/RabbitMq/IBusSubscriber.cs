using MicroApp.Common.Messages;
using MicroApp.Common.Types;
using System;

namespace MicroApp.Common.RabbitMq
{
    public interface IBusSubscriber
    {
        IBusSubscriber SubscribeCommand<TCommand>(string @namespace = null, string queueName = null,
            Func<TCommand, MicroAppException, IRejectedEvent> onError = null)
            where TCommand : ICommand;

        IBusSubscriber SubscribeEvent<TEvent>(string @namespace = null, string queueName = null,
            Func<TEvent, MicroAppException, IRejectedEvent> onError = null) 
            where TEvent : IEvent;
    }
}
