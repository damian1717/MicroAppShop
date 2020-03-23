using MicroApp.Common.Handlers;
using MicroApp.Documents.Api.Dto;
using MicroApp.Documents.Api.Queries;
using MicroApp.Documents.Api.Repositories;
using System.Threading.Tasks;

namespace MicroApp.Documents.Api.Handler
{
    public class GetDocumentByIdHandler : IQueryHandler<GetDocumentById, DocumentDto>
    {
        private readonly IDocumentRepository _documentRepository;
        public GetDocumentByIdHandler(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }
        public async Task<DocumentDto> HandleAsync(GetDocumentById query)
        {
            var document = await _documentRepository.GetAsync(query.Id);
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
