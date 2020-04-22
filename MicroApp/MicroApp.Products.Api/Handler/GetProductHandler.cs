using MicroApp.Common.Handlers;
using MicroApp.Products.Api.Dto;
using MicroApp.Products.Api.Queries;
using MicroApp.Products.Api.Repositories;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MicroApp.Products.Api.Handler
{
    public class GetProductHandler : IQueryHandler<GetProduct, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<GetProductHandler> _logger;
        public GetProductHandler(IProductRepository productRepository, ILogger<GetProductHandler> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<ProductDto> HandleAsync(GetProduct query)
        {
            _logger.LogInformation($"Geting product by Id: '{query.Id}'");
            var product = await _productRepository.GetAsync(query.Id);
            _logger.LogInformation($"Got product by Id: '{query.Id}'");
            return product == null ? null : new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Price = product.Price
            };
        }
    }
}
