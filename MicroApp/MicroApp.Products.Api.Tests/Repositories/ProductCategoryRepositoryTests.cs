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
    public class ProductCategoryRepositoryTests
    {
        private readonly IProductCategoryRepository _repository;
        private Guid _guid;
        private ProductCategory _productCategory;
        private Mock<IMongoRepository<ProductCategory>> _mockMongoRepository;
        public ProductCategoryRepositoryTests()
        {
            _guid = Guid.NewGuid();
            _productCategory = new ProductCategory(_guid, "");
            _mockMongoRepository = new Mock<IMongoRepository<ProductCategory>>();
            _repository = new ProductCategoryRepository(_mockMongoRepository.Object);
        }

        [Fact]
        public async Task getasync_return_valid_result_when_request_valid()
        {
            //Arange
            _mockMongoRepository.Setup(s => s.GetAsync(_guid)).ReturnsAsync(_productCategory);

            //Act
            var result = await _repository.GetAsync(_guid);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(_guid, result.Id);
        }

        [Fact]
        public async Task getasync_return_once_time()
        {
            //Arange
            _mockMongoRepository.Setup(s => s.GetAsync(_guid)).ReturnsAsync(_productCategory);

            //Act
            var result = await _repository.GetAsync(_guid);

            //Assert
            _mockMongoRepository.Verify(r => r.GetAsync(_guid), Times.Once);
        }

        [Fact]
        public async Task addasync_invoke_once_time()
        {
            //Arrange 
            _mockMongoRepository.Setup(s => s.AddAsync(_productCategory)).Returns(Task.CompletedTask);

            //Act
            await _repository.AddAsync(_productCategory);

            //Assert
            _mockMongoRepository.Verify(r => r.AddAsync(_productCategory), Times.Once);
        }

        [Fact]
        public async Task browseasync_return_null()
        {
            //Arange
            var query = new BrowseProductCategory();
            _mockMongoRepository.Setup(s => s.BrowseAsync(q => q.Name != "", query)).ReturnsAsync((PagedResult<ProductCategory>)null);

            //Act
            var result = await _repository.BrowseAsync(query);

            //Assert
            Assert.Null(result);
        }
    }
}
