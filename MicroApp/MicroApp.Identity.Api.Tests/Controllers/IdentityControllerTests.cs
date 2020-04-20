using MicroApp.Identity.Api.Services;
using Moq;

namespace MicroApp.Identity.Api.Tests.Controllers
{
    public class IdentityControllerTests
    {
        protected readonly Mock<IIdentityService> _iIdentityService;
        public IdentityControllerTests()
        {
            _iIdentityService = new Mock<IIdentityService>();
        }
    }
}
