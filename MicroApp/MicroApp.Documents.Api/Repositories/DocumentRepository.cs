using System;
using System.Threading.Tasks;
using MicroApp.Common.Mongo;
using MicroApp.Documents.Api.Domain;

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
    }
}
