using MicroApp.Common.Handlers;
using MicroApp.Documents.Api.Dto;
using MicroApp.Documents.Api.Queries;
using MicroApp.Documents.Api.Repositories;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace MicroApp.Documents.Api.Handler
{
    public class BrowseDocumentsByExternalIdHandler : IQueryHandler<BrowseDocumentsByExternalId, DocumentDto[]>
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly ILogger<BrowseDocumentsByExternalIdHandler> _logger;
        public BrowseDocumentsByExternalIdHandler(IDocumentRepository documentRepository, ILogger<BrowseDocumentsByExternalIdHandler> logger)
        {
            _documentRepository = documentRepository;
            _logger = logger;
        }

        public async Task<DocumentDto[]> HandleAsync(BrowseDocumentsByExternalId query)
        {
            _logger.LogInformation("Browsing documents by Ids");
            var pagedResults = await _documentRepository.BrowseAsync(query);
            _logger.LogInformation("Browsed documents by Ids");
            var documents = pagedResults.Items.Select(d => new DocumentDto
            {
                Id = d.Id,
                FileName = d.FileName,
                FileArray = d.FileArray,
                ExternalId = d.ExternalId
            }).ToList();
            return documents.ToArray();
        }
    }
}
