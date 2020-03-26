using MicroApp.Api.Messages.Commands.ProductCategory;
using MicroApp.Api.Messages.Commands.Products;
using MicroApp.Api.Queries.Products;
using MicroApp.Api.Services;
using MicroApp.Common.Mvc;
using MicroApp.Common.RabbitMq;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;
using System.Threading.Tasks;

namespace MicroApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IProductsService _productsService;
        public ProductsController(IBusPublisher busPublisher, ITracer tracer, IProductsService productsService) : base(busPublisher, tracer)
        {
            _productsService = productsService;
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(AddProduct command)
            => await SendAsync(command, resourceId: command.Id, resource: "products");

        [HttpPost("AddProductCategory")]
        public async Task<IActionResult> AddProductCategory(AddProductCategory command)
            => await SendAsync(command.BindId(c => c.Id), resourceId: command.Id, resource: "products");

        [HttpGet("GetAllProductCategories")]
        public async Task<IActionResult> GetAllProductCategories([FromQuery] BrowseProductCategory query)
            => Collection(await _productsService.GetAllProductCategories(query));

        [HttpGet("GetAllProductByCategoryId")]
        public async Task<IActionResult> GetAllProductByCategoryId([FromQuery] BrowseProduct query)
            => Collection(await _productsService.GetAllProductByCategoryId(query));
    }
}