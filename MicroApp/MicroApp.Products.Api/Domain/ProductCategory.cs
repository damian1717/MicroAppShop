using MicroApp.Common.Types;
using System;

namespace MicroApp.Products.Api.Domain
{
    public class ProductCategory : IIdentifiable
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        protected ProductCategory()
        {
        }
        public ProductCategory(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
