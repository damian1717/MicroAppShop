using MicroApp.Common.Types;
using MicroApp.Products.Api.Domain;
using MicroApp.Products.Api.Queries;
using System.Threading.Tasks;

namespace MicroApp.Products.Api.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task<PagedResult<Product>> BrowseAsync(BrowseProduct query);
    }
}
