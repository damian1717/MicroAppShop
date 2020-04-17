using MicroApp.Products.Api.Controllers;
using MicroApp.Products.Api.Dto;
using MicroApp.Products.Api.Queries;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace MicroApp.Products.Api.Tests.Controllers
{
    public class GetProductByIdTests: ProductsControllerTests
    {
        [Fact]
        public async Task return_null_when_getProduct_equal_null()
        {
            // Arrange 
            GetProduct query = null;
            _mockDispatcher.Setup(r => r.QueryAsync(query)).ReturnsAsync((ProductDto)null);

            // Act
            var controller = new ProductsController(_mockDispatcher.Object);
            var result = await controller.GetProductById(query);

            //Assert
            Assert.Null(result.Value);
            Assert.IsType<ActionResult<ProductDto>>(result);
        }

        [Fact]
        public async Task return_items_when_getProduct_not_null()
        {
            // Arrange 
            var query = new GetProduct();
            var productDto = new ProductDto();
            _mockDispatcher.Setup(r => r.QueryAsync(query)).ReturnsAsync(productDto);

            // Act
            var controller = new ProductsController(_mockDispatcher.Object);
            var result = await controller.GetProductById(query);

            //Assert
            Assert.NotNull(result.Result);
            Assert.IsType<ActionResult<ProductDto>>(result);
        }
    }
}
