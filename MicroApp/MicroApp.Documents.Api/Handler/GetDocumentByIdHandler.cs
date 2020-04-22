using MicroApp.Common.Handlers;
using MicroApp.Documents.Api.Dto;
using MicroApp.Documents.Api.Queries;
using MicroApp.Documents.Api.Repositories;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MicroApp.Documents.Api.Handler
{
    public class GetDocumentByIdHandler : IQueryHandler<GetDocumentById, DocumentDto>
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly ILogger<GetDocumentByIdHandler> _logger;
        public GetDocumentByIdHandler(IDocumentRepository documentRepository, ILogger<GetDocumentByIdHandler> logger)
        {
            _documentRepository = documentRepository;
            _logger = logger;
        }
        public async Task<DocumentDto> HandleAsync(GetDocumentById query)
        {
            _logger.LogInformation($"Geting document by ExternalId: '{query.Id}'");
            var document = await _documentRepository.GetAsync(query.Id);
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
