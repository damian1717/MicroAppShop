using MicroApp.Common.Mongo;
using MicroApp.Common.Types;
using MicroApp.Products.Api.Domain;
using MicroApp.Products.Api.Queries;
using MicroApp.Products.Api.Repositories;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MicroApp.Products.Api.Tests.Repositories
{
    public class ProductRepositoryTests
    {
        private readonly IProductRepository _repository;
        private Guid _guid;
        private Product _product;
        private Mock<IMongoRepository<Product>> _mockMongoRepository;
        public ProductRepositoryTests()
        {
            _guid = Guid.NewGuid();
            _product = new Product(_guid, "", "", 1, _guid);
            _mockMongoRepository = new Mock<IMongoRepository<Product>>();
            _repository = new ProductRepository(_mockMongoRepository.Object);
        }

        [Fact]
        public async Task getasync_return_valid_result_when_request_valid()
        {
            //Arange
            _mockMongoRepository.Setup(s => s.GetAsync(_guid)).ReturnsAsync(_product);

            //Act
            var result = await _repository.GetAsync(_guid);

            //Assert
            _mockMongoRepository.Verify(r => r.GetAsync(_guid), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(_guid, result.Id);
            Assert.Equal(_guid, result.CategoryId);
        }

        [Fact]
        public async Task getasync_return_once_time()
        {
            //Arange
            _mockMongoRepository.Setup(s => s.GetAsync(_guid)).ReturnsAsync(_product);

            //Act
            var result = await _repository.GetAsync(_guid);

            //Assert
            _mockMongoRepository.Verify(r => r.GetAsync(_guid), Times.Once);
        }

        [Fact]
        public async Task addasync_invoke_once_time()
        {
            //Arrange 
            _mockMongoRepository.Setup(s => s.AddAsync(_product)).Returns(Task.CompletedTask);

            //Act
            await _repository.AddAsync(_product);

            //Assert
            _mockMongoRepository.Verify(r => r.AddAsync(_product), Times.Once);
        }

        [Fact]
        public async Task browseasync_return_null()
        {
            //Arange
            var query = new BrowseProduct();
            _mockMongoRepository.Setup(s => s.BrowseAsync(r => r.CategoryId == query.Id, query)).ReturnsAsync((PagedResult<Product>)null);

            //Act
            var result = await _repository.BrowseAsync(query);

            //Assert
            Assert.Null(result);
        }
    }
}
