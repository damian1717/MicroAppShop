using MicroApp.Common.Handlers;
using MicroApp.Common.Types;
using MicroApp.Products.Api.Dto;
using MicroApp.Products.Api.Queries;
using MicroApp.Products.Api.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace MicroApp.Products.Api.Handler
{
    public class BrowseProductHandler : IQueryHandler<BrowseProduct, PagedResult<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        public BrowseProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<PagedResult<ProductDto>> HandleAsync(BrowseProduct query)
        {
            var pagedResult = await _productRepository.BrowseAsync(query);
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
