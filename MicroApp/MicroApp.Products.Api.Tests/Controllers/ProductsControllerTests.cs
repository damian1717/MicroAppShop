using MicroApp.Common.Dispatcher;
using Moq;

namespace MicroApp.Products.Api.Tests.Controllers
{
    public class ProductsControllerTests
    {
        protected readonly Mock<IDispatcher> _mockDispatcher;
        public ProductsControllerTests()
        {
            _mockDispatcher = new Mock<IDispatcher>();
        }
    }
}
