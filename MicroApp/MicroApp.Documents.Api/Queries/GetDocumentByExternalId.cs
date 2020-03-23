using MicroApp.Common.Types;
using MicroApp.Documents.Api.Dto;
using System;

namespace MicroApp.Documents.Api.Queries
{
    public class GetDocumentByExternalId : IQuery<DocumentDto>
    {
        public Guid Id { get; set; }
    }
}
