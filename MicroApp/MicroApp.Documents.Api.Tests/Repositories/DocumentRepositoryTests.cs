using MicroApp.Common.Mongo;
using MicroApp.Documents.Api.Domain;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MicroApp.Documents.Api.Repositories
{
    public class DocumentRepositoryTests
    {
        private readonly IDocumentRepository _repository;
        private Guid _guid;
        private Document _document;
        private Mock<IMongoRepository<Document>> _mockMongoRepository;
        public DocumentRepositoryTests()
        {
            _guid = Guid.NewGuid();
            _document = new Document(_guid, null, null, _guid);
            _mockMongoRepository = new Mock<IMongoRepository<Document>>();
            _repository = new DocumentRepository(_mockMongoRepository.Object);
        }

        [Fact]
        public async Task getasync_return_valid_result_when_request_valid()
        {
            //Arange
            _mockMongoRepository.Setup(s => s.GetAsync(_guid)).ReturnsAsync(_document);

            //Act
            var result = await _repository.GetAsync(_guid);

            //Assert
            _mockMongoRepository.Verify(r => r.GetAsync(_guid), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(_guid, result.Id);
            Assert.Equal(_guid, result.ExternalId);
        }

        [Fact]
        public async Task getasync_return_once_time()
        {
            //Arange
            _mockMongoRepository.Setup(s => s.GetAsync(_guid)).ReturnsAsync(_document);

            //Act
            var result = await _repository.GetAsync(_guid);

            //Assert
            _mockMongoRepository.Verify(r => r.GetAsync(_guid), Times.Once);
        }

        [Fact]
        public async Task addasync_invoke_once_time()
        {
            //Arrange 
            _mockMongoRepository.Setup(s => s.AddAsync(_document)).Returns(Task.CompletedTask);

            //Act
            await _repository.AddAsync(_document);

            //Assert
            _mockMongoRepository.Verify(r => r.AddAsync(_document), Times.Once);
        }

        [Fact]
        public async Task getdocumentbyexternalidasync_invoke_never()
        {
            //Arrange 
            _mockMongoRepository.Setup(s => s.GetAsync(null)).ReturnsAsync(_document);

            //Act
            await _repository.GetDocumentByExternalIdAsync(null);

            //Assert
            _mockMongoRepository.Verify(r => r.GetAsync(null), Times.Never);
        }
    }
}
