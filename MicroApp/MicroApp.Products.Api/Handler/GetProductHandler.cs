using MicroApp.Common.Handlers;
using MicroApp.Products.Api.Dto;
using MicroApp.Products.Api.Queries;
using MicroApp.Products.Api.Repositories;
using System.Threading.Tasks;

namespace MicroApp.Products.Api.Handler
{
    public class GetProductHandler : IQueryHandler<GetProduct, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        public GetProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> HandleAsync(GetProduct query)
        {
            var product = await _productRepository.GetAsync(query.Id);
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
