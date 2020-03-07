using MicroApp.Common.Messages;
using Newtonsoft.Json;
using System;

namespace MicroApp.Products.Api.Messages.Events
{
    public class ProductAdded: IEvent
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }

        [JsonConstructor]
        public ProductAdded(Guid id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
