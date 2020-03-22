using MicroApp.Common.Types;
using MicroApp.Documents.Api.Dto;
using System;

namespace MicroApp.Documents.Api.Queries
{
    public class GetDocument : IQuery<DocumentDto>
    {
        public Guid Id { get; set; }
    }
}
