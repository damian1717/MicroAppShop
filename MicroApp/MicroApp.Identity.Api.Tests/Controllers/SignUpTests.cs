using MicroApp.Identity.Api.Controllers;
using MicroApp.Identity.Api.Messages.Commands;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MicroApp.Identity.Api.Tests.Controllers
{
    public class SignUpTests: IdentityControllerTests
    {
        [Fact]
        public async Task return_not_null_when_request_properly()
        {
            // Arrange 
            var command = new SignUp(Guid.NewGuid(), "test@test.com", "password", "user");
            _iIdentityService.Setup(r => r.SignUpAsync(Guid.NewGuid(), "test@test.com", "password", "user")).Returns(Task.CompletedTask);

            // Act
            var controller = new IdentityController(_iIdentityService.Object);
            var result = await controller.SignUp(command);

            //Assert
            Assert.NotNull(result);
            _iIdentityService.Verify();
        }
    }
}
