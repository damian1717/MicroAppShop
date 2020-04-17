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
    public class GetAllProductByCategoryIdTests: ProductsControllerTests
    {
        [Fact]
        public async Task return_null_when_browseProduct_equal_null()
        {
            // Arrange 
            BrowseProduct query = null;
            _mockDispatcher.Setup(r => r.QueryAsync(query)).ReturnsAsync((PagedResult<ProductDto>)null);

            // Act
            var controller = new ProductsController(_mockDispatcher.Object);
            var result = await controller.GetAllProductByCategoryId(query);

            //Assert
            Assert.Null(result.Value);
            Assert.IsType<ActionResult<PagedResult<ProductDto>>>(result);
        }

        [Fact]
        public async Task return_items_when_browseProduct_not_null()
        {
            // Arrange 
            var query = new BrowseProduct();

            var productDtos = new List<ProductDto> { new ProductDto() };
            var pagedResultBaseMock = new PagedResultBaseMock();
            var pageProducts = PagedResult<ProductDto>.From(pagedResultBaseMock, productDtos);
            _mockDispatcher.Setup(r => r.QueryAsync(query)).ReturnsAsync(pageProducts);

            // Act
            var controller = new ProductsController(_mockDispatcher.Object);
            var result = await controller.GetAllProductByCategoryId(query);

            //Assert
            Assert.NotNull(result.Result);
            Assert.IsType<ActionResult<PagedResult<ProductDto>>>(result);
        }

        private class PagedResultBaseMock : PagedResultBase
        {
        }
    }
}
