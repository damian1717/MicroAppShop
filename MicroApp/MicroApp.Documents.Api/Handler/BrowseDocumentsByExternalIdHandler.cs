using MicroApp.Common.Handlers;
using MicroApp.Documents.Api.Dto;
using MicroApp.Documents.Api.Queries;
using MicroApp.Documents.Api.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace MicroApp.Documents.Api.Handler
{
    public class BrowseDocumentsByExternalIdHandler : IQueryHandler<BrowseDocumentsByExternalId, DocumentDto[]>
    {
        private readonly IDocumentRepository _documentRepository;
        public BrowseDocumentsByExternalIdHandler(IDocumentRepository documentRepository)
            => _documentRepository = documentRepository;

        public async Task<DocumentDto[]> HandleAsync(BrowseDocumentsByExternalId query)
        {
            var pagedResults = await _documentRepository.BrowseAsync(query);
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
