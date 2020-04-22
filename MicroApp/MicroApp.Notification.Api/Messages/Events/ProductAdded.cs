using MicroApp.Common.Messages;
using Newtonsoft.Json;
using System;

namespace MicroApp.Notification.Api.Messages.Events
{
    [MessageNamespace("products")]
    public class ProductAdded : IEvent
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public Guid CategoryId { get; }

        [JsonConstructor]
        public ProductAdded(Guid id, string name, string description, decimal price, Guid categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }
    }
}
