using MicroApp.Common.Handlers;
using MicroApp.Common.Types;
using MicroApp.Products.Api.Dto;
using MicroApp.Products.Api.Queries;
using MicroApp.Products.Api.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace MicroApp.Products.Api.Handler
{
    public class BrowseProductCategoryHandler : IQueryHandler<BrowseProductCategory, PagedResult<ProductCategoryDto>>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        public BrowseProductCategoryHandler(IProductCategoryRepository productCategoryRepository)
            => _productCategoryRepository = productCategoryRepository;

        public async Task<PagedResult<ProductCategoryDto>> HandleAsync(BrowseProductCategory query)
        {
            var pagedResult = await _productCategoryRepository.BrowseAsync(query);
            var productCategory = pagedResult.Items.Select(p => new ProductCategoryDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return PagedResult<ProductCategoryDto>.From(pagedResult, productCategory);
        }
    }
}
