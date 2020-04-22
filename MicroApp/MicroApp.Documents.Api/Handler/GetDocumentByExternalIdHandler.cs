using MicroApp.Common.Handlers;
using MicroApp.Documents.Api.Dto;
using MicroApp.Documents.Api.Queries;
using MicroApp.Documents.Api.Repositories;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MicroApp.Documents.Api.Handler
{
    public class GetDocumentByExternalIdHandler : IQueryHandler<GetDocumentByExternalId, DocumentDto>
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly ILogger<GetDocumentByExternalIdHandler> _logger;
        public GetDocumentByExternalIdHandler(IDocumentRepository documentRepository, ILogger<GetDocumentByExternalIdHandler> logger)
        {
            _documentRepository = documentRepository;
            _logger = logger;
        }
        public async Task<DocumentDto> HandleAsync(GetDocumentByExternalId query)
        {
            _logger.LogInformation($"Geting document by ExternalId: '{query.Id}'");
            var document = await _documentRepository.GetDocumentByExternalIdAsync(query);
            _logger.LogInformation($"Got document by ExternalId: '{query.Id}'");
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
