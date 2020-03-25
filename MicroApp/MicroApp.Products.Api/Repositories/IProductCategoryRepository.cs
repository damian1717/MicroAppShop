using MicroApp.Products.Api.Domain;
using System;
using System.Threading.Tasks;

namespace MicroApp.Products.Api.Repositories
{
    public interface IProductCategoryRepository
    {
        Task AddAsync(ProductCategory productCategory);
        Task<ProductCategory> GetAsync(Guid id);
    }
}
