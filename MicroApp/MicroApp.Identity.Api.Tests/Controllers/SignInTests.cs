using MicroApp.Common.Authentication;
using MicroApp.Identity.Api.Controllers;
using MicroApp.Identity.Api.Messages.Commands;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace MicroApp.Identity.Api.Tests.Controllers
{
    public class SignInTests: IdentityControllerTests
    {
        [Fact]
        public async Task return_not_null_when_request_properly()
        {
            // Arrange 
            var token = new JsonWebToken();
            var command = new SignIn("test@test.com", "password");
            _iIdentityService.Setup(r => r.SignInAsync("test@test.com", "password")).ReturnsAsync(token);

            // Act
            var controller = new IdentityController(_iIdentityService.Object);
            var result = await controller.SignIn(command) as OkObjectResult;

            // Assert
            Assert.NotNull(result.Value);
            _iIdentityService.Verify();
        }

        [Fact]
        public async Task return_null_when_request_null()
        {
            // Arrange 
            var command = new SignIn("test@test.com", "password");
            _iIdentityService.Setup(r => r.SignInAsync("test@test.com", "password")).ReturnsAsync((JsonWebToken)null);

            // Act
            var controller = new IdentityController(_iIdentityService.Object);
            var result = await controller.SignIn(command) as OkObjectResult;

            // Assert
            Assert.Null(result.Value);
        }
    }
}
