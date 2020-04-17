using MicroApp.Common.RabbitMq;
using MicroApp.Products.Api.Domain;
using MicroApp.Products.Api.Handler;
using MicroApp.Products.Api.Messages.Commands;
using MicroApp.Products.Api.Repositories;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MicroApp.Products.Api.Tests.Handler
{
    public class AddProductHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepository;
        private readonly Mock<IBusPublisher> _busPublisher;
        private readonly Mock<ICorrelationContext> _context;
        private readonly Guid _guid;
        public AddProductHandlerTests()
        {
            _guid = Guid.NewGuid();
            _productRepository = new Mock<IProductRepository>();
            _busPublisher = new Mock<IBusPublisher>();
            _context = new Mock<ICorrelationContext>();
        }

        [Fact]
        public async Task return_expected_result()
        {
            //Arrange 
            var product = new Product(_guid, "", "", 1, _guid);
            var command = new AddProduct(_guid, "", "", 1, _guid);
            _productRepository.Setup(r => r.AddAsync(product)).Returns(Task.CompletedTask);

            //Act
            var handler = new AddProductHandler(_busPublisher.Object, _productRepository.Object);
            await handler.HandleAsync(command, _context.Object);

            //Assert
            _productRepository.Verify();
            _busPublisher.Verify();
        }
    }
}
