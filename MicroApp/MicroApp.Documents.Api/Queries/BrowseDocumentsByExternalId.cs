using MicroApp.Common.Types;
using MicroApp.Documents.Api.Dto;
using System;

namespace MicroApp.Documents.Api.Queries
{
    public class BrowseDocumentsByExternalId : PagedQueryBase, IQuery<DocumentDto[]>
    {
        public Guid[] Ids { get; set; }
    }
}
