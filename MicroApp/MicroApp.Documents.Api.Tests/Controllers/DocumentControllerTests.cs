using MicroApp.Common.Dispatcher;
using Moq;

namespace MicroApp.Documents.Api
{
    public class DocumentControllerTests
    {
        protected readonly Mock<IDispatcher> _mockDispatcher;
        public DocumentControllerTests()
        {
            _mockDispatcher = new Mock<IDispatcher>();
        }
    }
}
