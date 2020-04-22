using MicroApp.Common.RabbitMq;
using MicroApp.Documents.Api.Domain;
using MicroApp.Documents.Api.Messages.Commands;
using MicroApp.Documents.Api.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MicroApp.Documents.Api.Handler
{
    public class AddDocumentHandlerTests
    {
        private readonly Mock<IDocumentRepository> _documentRepository;
        private readonly Mock<IBusPublisher> _busPublisher;
        private readonly Mock<ICorrelationContext> _context;
        private readonly Guid _guid;
        private readonly Mock<ILogger<AddDocumentHandler>> _logger;
        public AddDocumentHandlerTests()
        {
            _guid = Guid.NewGuid();
            _documentRepository = new Mock<IDocumentRepository>();
            _busPublisher = new Mock<IBusPublisher>();
            _context = new Mock<ICorrelationContext>();
            _logger = new Mock<ILogger<AddDocumentHandler>>();
        }

        [Fact]
        public async Task return_expected_result()
        {
            //Arrange 
            var document = new Document(_guid, null, null, _guid);
            var command = new AddDocument(_guid, null, null, _guid);
            _documentRepository.Setup(r => r.AddAsync(document)).Returns(Task.CompletedTask);

            //Act
            var handler = new AddDocumentHandler(_busPublisher.Object, _documentRepository.Object, _logger.Object);
            await handler.HandleAsync(command, _context.Object);

            //Assert
            _documentRepository.Verify();
            _busPublisher.Verify();
        }
    }
}
