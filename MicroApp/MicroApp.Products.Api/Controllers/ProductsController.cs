using MicroApp.Common.Dispatcher;
using MicroApp.Common.Types;
using MicroApp.Products.Api.Dto;
using MicroApp.Products.Api.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MicroApp.Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        public ProductsController(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById([FromRoute] GetProduct query)
            => Single(await QueryAsync(query));

        [HttpGet("GetAllProductCategories")]
        public async Task<ActionResult<PagedResult<ProductCategoryDto>>> Get([FromQuery] BrowseProductCategory query)
            => Collection(await QueryAsync(query));

        [HttpGet("GetAllProductByCategoryId")]
        public async Task<ActionResult<PagedResult<ProductDto>>> GetAllProductByCategoryId([FromQuery] BrowseProduct query)
            => Collection(await QueryAsync(query));
    }
}