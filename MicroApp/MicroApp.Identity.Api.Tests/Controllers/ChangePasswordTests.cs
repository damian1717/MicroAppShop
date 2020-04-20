using MicroApp.Identity.Api.Controllers;
using MicroApp.Identity.Api.Messages.Commands;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MicroApp.Identity.Api.Tests.Controllers
{
    public class ChangePasswordTests: IdentityControllerTests
    {
        [Fact]
        public async Task return_not_null_when_request_properly()
        {
            // Arrange 
            var command = new ChangePassword(Guid.NewGuid(), "currentPassword", "newPassword");
            _iIdentityService.Setup(r => r.ChangePasswordAsync(Guid.NewGuid(), "currentPassword", "newPassword")).Returns(Task.CompletedTask);

            // Act
            var controller = new IdentityController(_iIdentityService.Object);
            var result = await controller.ChangePassword(command);

            // Assert
            Assert.NotNull(result);
            _iIdentityService.Verify();
        }
    }
}
