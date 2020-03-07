using MicroApp.Products.Api.Domain;
using System.Threading.Tasks;

namespace MicroApp.Products.Api.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
    }
}
