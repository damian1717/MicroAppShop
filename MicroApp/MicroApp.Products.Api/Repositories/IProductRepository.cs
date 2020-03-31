using MicroApp.Common.Types;
using MicroApp.Products.Api.Domain;
using MicroApp.Products.Api.Queries;
using System;
using System.Threading.Tasks;

namespace MicroApp.Products.Api.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task<Product> GetAsync(Guid id);
        Task<PagedResult<Product>> BrowseAsync(BrowseProduct query);
    }
}
