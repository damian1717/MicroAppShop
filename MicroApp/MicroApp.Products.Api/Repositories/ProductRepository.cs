using System;
using System.Threading.Tasks;
using MicroApp.Common.Mongo;
using MicroApp.Common.Types;
using MicroApp.Products.Api.Domain;
using MicroApp.Products.Api.Queries;

namespace MicroApp.Products.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoRepository<Product> _repository;

        public ProductRepository(IMongoRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Product product)
            => await _repository.AddAsync(product);

        public async Task<Product> GetAsync(Guid id)
            => await _repository.GetAsync(id);

        public async Task<PagedResult<Product>> BrowseAsync(BrowseProduct query)
            => await _repository.BrowseAsync(q => q.CategoryId == query.Id, query);
    }
}
