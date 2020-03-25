using System;
using MicroApp.Common.Types;

namespace MicroApp.Products.Api.Domain
{
    public class Product : IIdentifiable
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public Guid CategoryId { get; private set; }

        protected Product()
        {
        }

        public Product(Guid id, string name, string description, decimal price, Guid categoryId)
        {
            // TODO:: validation
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }
    }
}
