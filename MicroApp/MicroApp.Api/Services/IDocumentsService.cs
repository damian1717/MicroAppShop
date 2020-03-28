using MicroApp.Api.Models.Documents;
using MicroApp.Api.Queries.Documents;
using RestEase;
using System;
using System.Threading.Tasks;

namespace MicroApp.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IDocumentsService
    {
        [AllowAnyStatusCode]
        [Get("api/documents/getById/{id}")]
        Task<Document> GetByIdAsync([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("api/documents/getByExternalId/{id}")]
        Task<Document> GetByExternalIdAsync([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("api/documents/GetAllDocumentsByExternalId")]
        Task<Document[]> GetAllDocumentsByExternalId([Query] BrowseDocumentsByExternalId query);
    }
}
