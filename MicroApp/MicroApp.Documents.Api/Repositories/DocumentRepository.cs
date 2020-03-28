using System;
using System.Linq;
using System.Threading.Tasks;
using MicroApp.Common.Mongo;
using MicroApp.Common.Types;
using MicroApp.Documents.Api.Domain;
using MicroApp.Documents.Api.Queries;

namespace MicroApp.Documents.Api.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly IMongoRepository<Document> _repository;

        public DocumentRepository(IMongoRepository<Document> repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(Document document)
         => await _repository.AddAsync(document);

        public async Task<Document> GetAsync(Guid id)
            => await _repository.GetAsync(id);

        public async Task<Document> GetDocumentByExternalIdAsync(GetDocumentByExternalId query)
        => await _repository.GetAsync(p => p.ExternalId == query.Id);

        public async Task<PagedResult<Document>> BrowseAsync(BrowseDocumentsByExternalId query)
            => await _repository.BrowseAsync(q => query.Ids.Contains(q.ExternalId), query);
    }
}
