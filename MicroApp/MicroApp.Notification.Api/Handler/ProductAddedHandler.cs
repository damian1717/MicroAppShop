using MicroApp.Common.Handlers;
using MicroApp.Common.MailKit;
using MicroApp.Common.RabbitMq;
using MicroApp.Notification.Api.Builders;
using MicroApp.Notification.Api.Messages.Events;
using MicroApp.Notification.Api.Services;
using MicroApp.Notification.Api.Templates;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MicroApp.Notification.Api.Handler
{
    public class ProductAddedHandler : IEventHandler<ProductAdded>
    {
        private readonly MailKitOptions _options;
        private readonly IMessagesService _messagesService;
        private readonly IUserService _userService;
        private readonly ILogger<ProductAddedHandler> _logger;
        public ProductAddedHandler(MailKitOptions options, IMessagesService messagesService, IUserService userService, ILogger<ProductAddedHandler> logger)
        {
            _options = options;
            _messagesService = messagesService;
            _userService = userService;
            _logger = logger;
        }
        public async Task HandleAsync(ProductAdded @event, ICorrelationContext context)
        {
            _logger.LogInformation($"Preparation for sending email for userId: '{context.UserId}'");
            var user = await _userService.GetUserByIdAsync(context.UserId);
            var productId = @event.Id.ToString("N");
            var message = MessageBuilder
                .Create()
                .WithReceiver(user.Email)
                .WithSender(_options.Email)
                .WithSubject(MessageTemplates.ProductAddedSubject, productId)
                .WithBody(MessageTemplates.ProductAddedBody, productId)
                .Build();

            _logger.LogInformation($"Preparation complete for sending email for userId: '{context.UserId}'");

            await _messagesService.SendAsync(message);
        }
    }
}
