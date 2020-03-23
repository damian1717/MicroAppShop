using MicroApp.Common.Handlers;
using MicroApp.Documents.Api.Dto;
using MicroApp.Documents.Api.Queries;
using MicroApp.Documents.Api.Repositories;
using System.Threading.Tasks;

namespace MicroApp.Documents.Api.Handler
{
    public class GetDocumentByExternalIdHandler : IQueryHandler<GetDocumentByExternalId, DocumentDto>
    {
        private readonly IDocumentRepository _documentRepository;
        public GetDocumentByExternalIdHandler(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }
        public async Task<DocumentDto> HandleAsync(GetDocumentByExternalId query)
        {
            var document = await _documentRepository.GetDocumentByExternalIdAsync(query);
            return document == null ? null : new DocumentDto
            {
                Id = document.Id,
                FileName = document.FileName,
                FileArray = document.FileArray,
                ExternalId = document.ExternalId
            };
        }
    }
}
