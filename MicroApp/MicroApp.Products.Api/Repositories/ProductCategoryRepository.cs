using System;
using System.Threading.Tasks;
using MicroApp.Common.Mongo;
using MicroApp.Products.Api.Domain;

namespace MicroApp.Products.Api.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly IMongoRepository<ProductCategory> _repository;

        public ProductCategoryRepository(IMongoRepository<ProductCategory> repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(ProductCategory productCategory)
            => await _repository.AddAsync(productCategory);

        public async Task<ProductCategory> GetAsync(Guid id)
            => await _repository.GetAsync(id);
    }
}
