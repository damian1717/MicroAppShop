using MicroApp.Common.Types;
using MicroApp.Products.Api.Dto;

namespace MicroApp.Products.Api.Queries
{
    public class BrowseProductCategory : PagedQueryBase, IQuery<PagedResult<ProductCategoryDto>>
    {
    }
}
