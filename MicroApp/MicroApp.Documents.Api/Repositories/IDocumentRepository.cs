using MicroApp.Common.Types;
using MicroApp.Documents.Api.Domain;
using MicroApp.Documents.Api.Queries;
using System;
using System.Threading.Tasks;

namespace MicroApp.Documents.Api.Repositories
{
    public interface IDocumentRepository
    {
        Task AddAsync(Document document);
        Task<Document> GetAsync(Guid id);
        Task<Document> GetDocumentByExternalIdAsync(GetDocumentByExternalId query);
        Task<PagedResult<Document>> BrowseAsync(BrowseDocumentsByExternalId query);
    }
}
