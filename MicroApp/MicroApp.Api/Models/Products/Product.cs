using MicroApp.Api.Models.Documents;
using System;

namespace MicroApp.Api.Models.Products
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public Document Document { get; set; }
    }
}
