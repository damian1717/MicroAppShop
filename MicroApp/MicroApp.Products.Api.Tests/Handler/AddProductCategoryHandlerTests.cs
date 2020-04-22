using MicroApp.Common.RabbitMq;
using MicroApp.Products.Api.Domain;
using MicroApp.Products.Api.Handler;
using MicroApp.Products.Api.Messages.Commands;
using MicroApp.Products.Api.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MicroApp.Products.Api.Tests.Handler
{
    public class AddProductCategoryHandlerTests
    {
        private readonly Mock<IProductCategoryRepository> _productCategoryRepository;
        private readonly Mock<IBusPublisher> _busPublisher;
        private readonly Mock<ICorrelationContext> _context;
        private readonly Mock<ILogger<AddProductCategoryHandler>> _logger;
        private readonly Guid _guid;
        public AddProductCategoryHandlerTests()
        {
            _guid = Guid.NewGuid();
            _productCategoryRepository = new Mock<IProductCategoryRepository>();
            _busPublisher = new Mock<IBusPublisher>();
            _context = new Mock<ICorrelationContext>();
            _logger = new Mock<ILogger<AddProductCategoryHandler>>();
        }

        [Fact]
        public async Task return_expected_result()
        {
            //Arrange 
            var productCategory = new ProductCategory(_guid, "");
            var command = new AddProductCategory(_guid, "");
            _productCategoryRepository.Setup(r => r.AddAsync(productCategory)).Returns(Task.CompletedTask);

            //Act
            var handler = new AddProductCategoryHandler(_busPublisher.Object, _productCategoryRepository.Object, _logger.Object);
            await handler.HandleAsync(command, _context.Object);

            //Assert
            _productCategoryRepository.Verify();
            _busPublisher.Verify();
        }
    }
}
