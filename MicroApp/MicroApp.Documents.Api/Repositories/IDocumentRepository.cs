using MicroApp.Documents.Api.Domain;
using System;
using System.Threading.Tasks;

namespace MicroApp.Documents.Api.Repositories
{
    public interface IDocumentRepository
    {
        Task AddAsync(Document document);
        Task<Document> GetAsync(Guid id);
    }
}
