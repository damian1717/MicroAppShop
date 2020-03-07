using MicroApp.Common.Messages;
using Newtonsoft.Json;
using System;

namespace MicroApp.Api.Messages.Commands.Products
{
    [MessageNamespace("products")]
    public class AddProduct : ICommand
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description {get;}
        public decimal Price { get; }

        [JsonConstructor]
        public AddProduct(Guid id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
