using MicroApp.Common.Types;
using MicroApp.Products.Api.Domain;
using MicroApp.Products.Api.Handler;
using MicroApp.Products.Api.Queries;
using MicroApp.Products.Api.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MicroApp.Products.Api.Tests.Handler
{
    public class BrowseProductCategoryHandlerTests
    {
        private readonly Mock<IProductCategoryRepository> _productCategoryRepository;
        private readonly Guid _guid;
        private ProductCategory _productCategory;
        private readonly BrowseProductCategory _query;
        public BrowseProductCategoryHandlerTests()
        {
            _guid = Guid.NewGuid();
            _productCategory = new ProductCategory(_guid, "");
            _query = new BrowseProductCategory();
            _productCategoryRepository = new Mock<IProductCategoryRepository>(); ;
        }

        [Fact]
        public async Task return_one_item_when_result_contains_one_item()
        {
            //Arrange 
            var productCategories = new List<ProductCategory>{ _productCategory };
            var pagedResultBaseMock = new PagedResultBaseMock();
            var pageProductCategories = PagedResult<ProductCategory>.From(pagedResultBaseMock, productCategories);
            _productCategoryRepository.Setup(r => r.BrowseAsync(_query)).ReturnsAsync(pageProductCategories);

            //Act
            var handler = new BrowseProductCategoryHandler(_productCategoryRepository.Object);
            var result = await handler.HandleAsync(_query);

            var productCategoryList = new List<ProductCategory>();
            foreach (var productCategory in result.Items)
            {
                productCategoryList.Add(new ProductCategory(productCategory.Id, productCategory.Name));
            }

            //Assert
            Assert.NotNull(result);
            Assert.Equal(productCategories.Count, productCategoryList.Count);
            Assert.Equal(productCategories[0].Name, productCategoryList[0].Name);
            Assert.Equal(productCategories[0].Id, productCategoryList[0].Id);
        }

        [Fact]
        public async Task return_0_items_when_not_contain_any_documents()
        {
            var productCategories = new List<ProductCategory>();
            var pagedResultBaseMock = new PagedResultBaseMock();
            var pageProductCategories = PagedResult<ProductCategory>.From(pagedResultBaseMock, productCategories);
            _productCategoryRepository.Setup(r => r.BrowseAsync(_query)).ReturnsAsync(pageProductCategories);

            //Act
            var handler = new BrowseProductCategoryHandler(_productCategoryRepository.Object);
            var result = await handler.HandleAsync(_query);

            var productCategoryList = new List<ProductCategory>();
            foreach (var productCategory in result.Items)
            {
                productCategoryList.Add(new ProductCategory(productCategory.Id, productCategory.Name));
            }

            //Assert
            Assert.NotNull(result);
            Assert.Equal(productCategories.Count, productCategoryList.Count);
        }

        private class PagedResultBaseMock : PagedResultBase
        {
        }
    }
}
