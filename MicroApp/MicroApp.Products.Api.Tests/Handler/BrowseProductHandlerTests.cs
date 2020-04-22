using MicroApp.Common.Types;
using MicroApp.Products.Api.Domain;
using MicroApp.Products.Api.Handler;
using MicroApp.Products.Api.Queries;
using MicroApp.Products.Api.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MicroApp.Products.Api.Tests.Handler
{
    public class BrowseProductHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepository;
        private readonly Mock<ILogger<BrowseProductHandler>> _logger;
        private readonly Guid _guid;
        private readonly BrowseProduct _query;
        public BrowseProductHandlerTests()
        {
            _guid = Guid.NewGuid();
            _query = new BrowseProduct();
            _productRepository = new Mock<IProductRepository>();
            _logger = new Mock<ILogger<BrowseProductHandler>>();
        }

        [Fact]
        public async Task return_one_item_when_result_contains_one_item()
        {
            //Arrange 
            var products = new List<Product>
            {
                new Product(_guid, "", "", 1, _guid)
            };
            var pagedResultBaseMock = new PagedResultBaseMock();
            var pageProducts = PagedResult<Product>.From(pagedResultBaseMock, products);
            _productRepository.Setup(r => r.BrowseAsync(_query)).ReturnsAsync(pageProducts);

            //Act
            var handler = new BrowseProductHandler(_productRepository.Object, _logger.Object);
            var result = await handler.HandleAsync(_query);

            var productList = new List<Product>();
            foreach (var product in result.Items)
            {
                productList.Add(new Product(product.Id, product.Name, product.Description, product.Price, product.CategoryId));
            }

            //Assert
            Assert.NotNull(result);
            Assert.Equal(products.Count, productList.Count);
            Assert.Equal(products[0].Name, productList[0].Name);
            Assert.Equal(products[0].Id, productList[0].Id);
            Assert.Equal(products[0].Description, productList[0].Description);
            Assert.Equal(products[0].Price, productList[0].Price);
            Assert.Equal(products[0].CategoryId, productList[0].CategoryId);
        }

        [Fact]
        public async Task return_0_items_when_not_contain_any_documents()
        {
            var products = new List<Product>();
            var pagedResultBaseMock = new PagedResultBaseMock();
            var pageProducts = PagedResult<Product>.From(pagedResultBaseMock, products);
            _productRepository.Setup(r => r.BrowseAsync(_query)).ReturnsAsync(pageProducts);

            //Act
            var handler = new BrowseProductHandler(_productRepository.Object, _logger.Object);
            var result = await handler.HandleAsync(_query);

            var productList = new List<Product>();
            foreach (var product in result.Items)
            {
                productList.Add(new Product(product.Id, product.Name, product.Description, product.Price, product.CategoryId));
            }

            //Assert
            Assert.NotNull(result);
            Assert.Equal(products.Count, productList.Count);
        }

        private class PagedResultBaseMock : PagedResultBase
        {
        }
    }
}
