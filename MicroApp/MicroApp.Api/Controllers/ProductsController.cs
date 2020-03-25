using MicroApp.Api.Messages.Commands.ProductCategory;
using MicroApp.Api.Messages.Commands.Products;
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
        public ProductsController(IBusPublisher busPublisher, ITracer tracer) : base(busPublisher, tracer)
        {
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(AddProduct command)
            => await SendAsync(command, resourceId: command.Id, resource: "products");

        [HttpPost("AddProductCategory")]
        public async Task<IActionResult> AddProductCategory(AddProductCategory command)
            => await SendAsync(command.BindId(c => c.Id), resourceId: command.Id, resource: "products");
    }
}