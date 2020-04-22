using MicroApp.Common.MailKit;
using MicroApp.Common.RabbitMq;
using MicroApp.Notification.Api.Dto;
using MicroApp.Notification.Api.Handler;
using MicroApp.Notification.Api.Messages.Events;
using MicroApp.Notification.Api.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MicroApp.Notification.Api.Tests.Handler
{
    public class ProductAddedHandlerTests
    {
        private readonly Mock<IUserService> _userService;
        private readonly Mock<MailKitOptions> _options;
        private readonly Mock<IMessagesService> _messagesService;
        private readonly Mock<ILogger<ProductAddedHandler>> _logger;
        private readonly Mock<ICorrelationContext> _context;
        public ProductAddedHandlerTests()
        {
            _userService = new Mock<IUserService>();
            _options = new Mock<MailKitOptions>();
            _messagesService = new Mock<IMessagesService>();
            _logger = new Mock<ILogger<ProductAddedHandler>>();
            _context = new Mock<ICorrelationContext>();
        }

        [Fact]
        public async Task return_expected_result()
        {
            /*
            //Arrange 
            var eventProductAdded = new ProductAdded(Guid.NewGuid(), "", "", 1, Guid.NewGuid());
            var userDto = new UserDto { Id = Guid.NewGuid() };
            _userService.Setup(r => r.GetUserByIdAsync(userDto.Id)).ReturnsAsync(userDto);

            //Act
            var handler = new ProductAddedHandler(_options.Object, _messagesService.Object, _userService.Object, _logger.Object);
            await handler.HandleAsync(eventProductAdded, _context.Object);

            //Assert
            _userService.Verify();
            */
        }
    }
}
