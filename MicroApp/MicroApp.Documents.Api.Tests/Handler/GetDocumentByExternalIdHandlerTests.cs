using MicroApp.Documents.Api.Domain;
using MicroApp.Documents.Api.Queries;
using MicroApp.Documents.Api.Repositories;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MicroApp.Documents.Api.Handler
{
    public class GetDocumentByExternalIdHandlerTests
    {
        private readonly Mock<IDocumentRepository> _documentRepository;
        private readonly Guid _guid;
        private readonly GetDocumentByExternalId _query;

        public GetDocumentByExternalIdHandlerTests()
        {
            _guid = Guid.NewGuid();
            _query = new GetDocumentByExternalId();
            _query.Id = _guid;
            _documentRepository = new Mock<IDocumentRepository>();
        }

        [Fact]
        public async Task return_expected_result()
        {
            //Arrange 
            var document = new Document(_guid, null, null, _guid);
            _documentRepository.Setup(r => r.GetDocumentByExternalIdAsync(_query)).ReturnsAsync(document);

            //Act
            var handler = new GetDocumentByExternalIdHandler(_documentRepository.Object);
            var result = await handler.HandleAsync(_query);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(document.Id, result.Id);
            Assert.Equal(document.ExternalId, result.ExternalId);
        }

        [Fact]
        public async Task return_null_when_not_found_document()
        {
            //Arrange 
            _documentRepository.Setup(r => r.GetDocumentByExternalIdAsync(_query)).Returns(Task.FromResult((Document)null));

            //Act
            var handler = new GetDocumentByExternalIdHandler(_documentRepository.Object);
            var result = await handler.HandleAsync(_query);

            //Assert
            Assert.Null(result);
        }
    }
}
