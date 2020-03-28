using MicroApp.Api.Messages.Commands.ProductCategory;
using MicroApp.Api.Messages.Commands.Products;
using MicroApp.Api.Models.Documents;
using MicroApp.Api.Models.Products;
using MicroApp.Api.Queries.Documents;
using MicroApp.Api.Queries.Products;
using MicroApp.Api.Services;
using MicroApp.Common.Mvc;
using MicroApp.Common.RabbitMq;
using MicroApp.Common.Types;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IProductsService _productsService;
        private readonly IDocumentsService _documentsService;
        public ProductsController(IBusPublisher busPublisher, ITracer tracer, IProductsService productsService, IDocumentsService documentsService) : base(busPublisher, tracer)
        {
            _productsService = productsService;
            _documentsService = documentsService;
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
        {
            var products = await _productsService.GetAllProductByCategoryId(query);
            Document[] documents = null;
            if (products.Items.Any())
                documents = await _documentsService.GetAllDocumentsByExternalId(InitializeBrowseDocumentsByExternalId(products));
            
            return Collection(ExtendProductByDocument(products, documents));
        }

        private static PagedResult<Product> ExtendProductByDocument(PagedResult<Product> products, Document[] documents)
        {
            foreach (var product in products.Items)
            {
                var document = documents.FirstOrDefault(x => x.ExternalId == product.Id);
                product.Document = document;
            }
            return products;
        }

        private static BrowseDocumentsByExternalId InitializeBrowseDocumentsByExternalId(PagedResult<Product> products)
        {
            var ids = new List<Guid>();

            foreach (var product in products.Items)
            {
                ids.Add(product.Id);
            }
            return new BrowseDocumentsByExternalId(ids.ToArray());
        }
    }
}