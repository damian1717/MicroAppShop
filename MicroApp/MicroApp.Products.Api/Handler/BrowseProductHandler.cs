using MicroApp.Common.Handlers;
using MicroApp.Common.Types;
using MicroApp.Products.Api.Dto;
using MicroApp.Products.Api.Queries;
using MicroApp.Products.Api.Repositories;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace MicroApp.Products.Api.Handler
{
    public class BrowseProductHandler : IQueryHandler<BrowseProduct, PagedResult<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<BrowseProductHandler> _logger;
        public BrowseProductHandler(IProductRepository productRepository, ILogger<BrowseProductHandler> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<PagedResult<ProductDto>> HandleAsync(BrowseProduct query)
        {
            _logger.LogInformation($"Browsing product by Id: '{query.Id}");
            var pagedResult = await _productRepository.BrowseAsync(query);
            _logger.LogInformation($"Browsed product by Id: '{query.Id}");
            var products = pagedResult.Items.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.CategoryId
            }).ToList();

            return PagedResult<ProductDto>.From(pagedResult, products);
        }
    }
}
