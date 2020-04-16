using MicroApp.Common.Types;
using MicroApp.Documents.Api.Domain;
using MicroApp.Documents.Api.Queries;
using MicroApp.Documents.Api.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MicroApp.Documents.Api.Handler
{
    public class BrowseDocumentsByExternalIdHandlerTests
    {
        private readonly Mock<IDocumentRepository> _documentRepository;
        private readonly Guid _guid;
        private readonly BrowseDocumentsByExternalId _query;
        public BrowseDocumentsByExternalIdHandlerTests()
        {
            _guid = Guid.NewGuid();
            _query = new BrowseDocumentsByExternalId();
            _documentRepository = new Mock<IDocumentRepository>();
        }

        private class PagedResultBaseMock : PagedResultBase
        {
        }

        [Fact]
        public async Task return_one_item_when_result_contains_one_item()
        {
            //Arrange 
            var documents = new List<Document>
            {
                new Document(_guid, null, null, _guid)
            };
            var pagedResultBaseMock = new PagedResultBaseMock();
            var pageDocuments = PagedResult<Document>.From(pagedResultBaseMock, documents);
            _documentRepository.Setup(r => r.BrowseAsync(_query)).ReturnsAsync(pageDocuments);

            //Act
            var handler = new BrowseDocumentsByExternalIdHandler(_documentRepository.Object);
            var result = await handler.HandleAsync(_query);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(documents.Count, result.Count());
        }
        
        [Fact]
        public async Task return_0_items_when_not_contain_any_documents()
        {
            var documents = new List<Document>();
            var pagedResultBaseMock = new PagedResultBaseMock();
            var pageDocuments = PagedResult<Document>.From(pagedResultBaseMock, documents);
            _documentRepository.Setup(r => r.BrowseAsync(_query)).ReturnsAsync(pageDocuments);

            //Act
            var handler = new BrowseDocumentsByExternalIdHandler(_documentRepository.Object);
            var result = await handler.HandleAsync(_query);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(documents.Count, result.Count());
        }
    }
}
