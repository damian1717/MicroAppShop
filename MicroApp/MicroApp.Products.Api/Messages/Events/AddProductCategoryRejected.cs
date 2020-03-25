using MicroApp.Common.Messages;
using Newtonsoft.Json;
using System;

namespace MicroApp.Products.Api.Messages.Events
{
    public class AddProductCategoryRejected : IRejectedEvent
    {
        public Guid Id { get; }
        public string Reason { get; }
        public string Code { get; }

        [JsonConstructor]
        public AddProductCategoryRejected(Guid id, string reason, string code)
        {
            Id = id;
            Reason = reason;
            Code = code;
        }
    }
}
