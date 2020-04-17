using MicroApp.Products.Api.Domain;
using MicroApp.Products.Api.Handler;
using MicroApp.Products.Api.Queries;
using MicroApp.Products.Api.Repositories;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MicroApp.Products.Api.Tests.Handler
{
    public class GetProductHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepository;
        private readonly Guid _guid;

        public GetProductHandlerTests()
        {
            _guid = Guid.NewGuid();
            _productRepository = new Mock<IProductRepository>();
        }

        [Fact]
        public async Task return_expected_result()
        {
            //Arrange 
            var product = new Product(_guid, "", "", 1, _guid);
            _productRepository.Setup(r => r.GetAsync(_guid)).ReturnsAsync(product);
            var query = new GetProduct();
            query.Id = _guid;

            //Act
            var handler = new GetProductHandler(_productRepository.Object);
            var result = await handler.HandleAsync(query);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(product.Id, result.Id);
            Assert.Equal(product.CategoryId, result.CategoryId);
        }

        [Fact]
        public async Task return_null_when_not_found_document()
        {
            //Arrange 
            _productRepository.Setup(r => r.GetAsync(_guid)).Returns(Task.FromResult((Product)null));
            var query = new GetProduct();

            //Act
            var handler = new GetProductHandler(_productRepository.Object);
            var result = await handler.HandleAsync(query);

            //Assert
            Assert.Null(result);
        }
    }
}
