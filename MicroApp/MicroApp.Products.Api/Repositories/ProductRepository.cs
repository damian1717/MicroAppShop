using System.Threading.Tasks;
using MicroApp.Common.Mongo;
using MicroApp.Products.Api.Domain;

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

    }
}
