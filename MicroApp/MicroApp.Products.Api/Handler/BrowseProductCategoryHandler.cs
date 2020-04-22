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
    public class BrowseProductCategoryHandler : IQueryHandler<BrowseProductCategory, PagedResult<ProductCategoryDto>>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly ILogger<BrowseProductCategoryHandler> _logger;
        public BrowseProductCategoryHandler(IProductCategoryRepository productCategoryRepository, ILogger<BrowseProductCategoryHandler> logger)
        {
            _productCategoryRepository = productCategoryRepository;
            _logger = logger;
        }

        public async Task<PagedResult<ProductCategoryDto>> HandleAsync(BrowseProductCategory query)
        {
            _logger.LogInformation("Browsing product categories by Ids");
            var pagedResult = await _productCategoryRepository.BrowseAsync(query);
            _logger.LogInformation("Browsed product categories by Ids");
            var productCategory = pagedResult.Items.Select(p => new ProductCategoryDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return PagedResult<ProductCategoryDto>.From(pagedResult, productCategory);
        }
    }
}
