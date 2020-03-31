using MicroApp.Common.Types;
using MicroApp.Products.Api.Dto;
using System;

namespace MicroApp.Products.Api.Queries
{
    public class GetProduct : IQuery<ProductDto>
    {
        public Guid Id { get; set; }
    }
}
