using System;

namespace MicroApp.Api.Queries.Products
{
    public class BrowseProduct : PagedQuery
    {
        public Guid Id { get; set; }
        public BrowseProduct()
        {
        }
    }
}
