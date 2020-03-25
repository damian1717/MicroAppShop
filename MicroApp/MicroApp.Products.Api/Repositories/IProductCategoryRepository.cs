using MicroApp.Common.Types;
using MicroApp.Products.Api.Domain;
using MicroApp.Products.Api.Queries;
using System;
using System.Threading.Tasks;

namespace MicroApp.Products.Api.Repositories
{
    public interface IProductCategoryRepository
    {
        Task AddAsync(ProductCategory productCategory);
        Task<ProductCategory> GetAsync(Guid id);
        Task<PagedResult<ProductCategory>> BrowseAsync(BrowseProductCategory query);
    }
}
