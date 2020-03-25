using MicroApp.Common.Messages;
using Newtonsoft.Json;
using System;

namespace MicroApp.Products.Api.Messages.Commands
{
    public class AddProductCategory : ICommand
    {
        public Guid Id { get; }
        public string Name { get; }
        [JsonConstructor]
        public AddProductCategory(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
