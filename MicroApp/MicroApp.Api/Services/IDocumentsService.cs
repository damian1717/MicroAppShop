using MicroApp.Api.Models.Documents;
using RestEase;
using System;
using System.Threading.Tasks;

namespace MicroApp.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IDocumentsService
    {
        [AllowAnyStatusCode]
        [Get("api/documents/{id}")]
        Task<Document> GetAsync([Path] Guid id);
    }
}
