using MicroApp.Common.Types;
using MicroApp.Products.Api.Controllers;
using MicroApp.Products.Api.Dto;
using MicroApp.Products.Api.Queries;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MicroApp.Products.Api.Tests.Controllers
{
    public class GetAllProductCategoriesTests : ProductsControllerTests
    {
        [Fact]
        public async Task return_null_when_browseProductCategory_equal_null()
        {
            // Arrange 
            BrowseProductCategory query = null;
            _mockDispatcher.Setup(r => r.QueryAsync(query)).ReturnsAsync((PagedResult<ProductCategoryDto>)null);

            // Act
            var controller = new ProductsController(_mockDispatcher.Object);
            var result = await controller.Get(query);

            //Assert
            Assert.Null(result.Value);
            Assert.IsType<ActionResult<PagedResult<ProductCategoryDto>>>(result);
        }

        [Fact]
        public async Task return_items_when_browseProductCategory_not_null()
        {
            // Arrange 
            var query = new BrowseProductCategory();

            var productCategoryDtos = new List<ProductCategoryDto> { new ProductCategoryDto() };
            var pagedResultBaseMock = new PagedResultBaseMock();
            var pageProductCategories = PagedResult<ProductCategoryDto>.From(pagedResultBaseMock, productCategoryDtos);
            _mockDispatcher.Setup(r => r.QueryAsync(query)).ReturnsAsync(pageProductCategories);

            // Act
            var controller = new ProductsController(_mockDispatcher.Object);
            var result = await controller.Get(query);

            //Assert
            Assert.NotNull(result.Result);
            Assert.IsType<ActionResult<PagedResult<ProductCategoryDto>>>(result);
        }

        private class PagedResultBaseMock : PagedResultBase
        {
        }
    }
}
