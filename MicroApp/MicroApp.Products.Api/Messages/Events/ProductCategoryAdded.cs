using MicroApp.Common.Messages;
using Newtonsoft.Json;
using System;

namespace MicroApp.Products.Api.Messages.Events
{
    public class ProductCategoryAdded : IEvent
    {
        public Guid Id { get; }
        public string Name { get; }
        [JsonConstructor]
        public ProductCategoryAdded(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
