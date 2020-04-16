using MicroApp.Documents.Api.Domain;
using MicroApp.Documents.Api.Queries;
using MicroApp.Documents.Api.Repositories;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MicroApp.Documents.Api.Handler
{
    public class GetDocumentByIdHandlerTests
    {
        private readonly Mock<IDocumentRepository> _documentRepository;
        private readonly Guid _guid;

        public GetDocumentByIdHandlerTests()
        {
            _guid = Guid.NewGuid();
            _documentRepository = new Mock<IDocumentRepository>();
        }

        [Fact]
        public async Task return_expected_result()
        {
            //Arrange 
            var document = new Document(_guid, null, null, _guid);
            _documentRepository.Setup(r => r.GetAsync(_guid)).ReturnsAsync(document);
            var query = new GetDocumentById();
            query.Id = _guid;

            //Act
            var handler = new GetDocumentByIdHandler(_documentRepository.Object);
            var result = await handler.HandleAsync(query);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(document.Id, result.Id);
            Assert.Equal(document.ExternalId, result.ExternalId);
        }

        [Fact]
        public async Task return_null_when_not_found_document()
        {
            //Arrange 
            _documentRepository.Setup(r => r.GetAsync(_guid)).Returns(Task.FromResult((Document)null));
            var query = new GetDocumentById();

            //Act
            var handler = new GetDocumentByIdHandler(_documentRepository.Object);
            var result = await handler.HandleAsync(query);

            //Assert
            Assert.Null(result);
        }
    }
}
