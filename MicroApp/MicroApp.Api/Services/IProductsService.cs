using MicroApp.Api.Models.Products;
using MicroApp.Api.Queries.Products;
using MicroApp.Common.Types;
using RestEase;
using System;
using System.Threading.Tasks;

namespace MicroApp.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IProductsService
    {
        [AllowAnyStatusCode]
        [Get("api/products/GetProductById/{id}")]
        Task<Product> GetProductById([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("api/products/GetAllProductCategories")]
        Task<PagedResult<ProductCategory>> GetAllProductCategories([Query] BrowseProductCategory query);

        [AllowAnyStatusCode]
        [Get("api/products/GetAllProductByCategoryId")]
        Task<PagedResult<Product>> GetAllProductByCategoryId([Query] BrowseProduct query);
    }
}
