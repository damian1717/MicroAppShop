using MicroApp.Common.Handlers;
using MicroApp.Common.RabbitMq;
using MicroApp.Documents.Api.Domain;
using MicroApp.Documents.Api.Messages.Commands;
using MicroApp.Documents.Api.Messages.Events;
using MicroApp.Documents.Api.Repositories;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MicroApp.Documents.Api.Handler
{
    public class AddDocumentHandler: ICommandHandler<AddDocument>
    {
        private readonly IBusPublisher _busPublisher;
        private readonly IDocumentRepository _documentRepository;
        private readonly ILogger<AddDocumentHandler> _logger;
        public AddDocumentHandler(IBusPublisher busPublisher, IDocumentRepository documentRepository, ILogger<AddDocumentHandler> logger)
        {
            _busPublisher = busPublisher;
            _documentRepository = documentRepository;
            _logger = logger;
        }

        public async Task HandleAsync(AddDocument command, ICorrelationContext context)
        {
            _logger.LogInformation($"Adding a document: name = {command.FileName}' documentId = '{command.Id}'");
            var document = new Document(command.Id, command.FileName, command.FileArray, command.ExternalId);
            await _documentRepository.AddAsync(document);
            _logger.LogInformation($"Added a document: name = {command.FileName}' documentId = '{command.Id}'");
            await _busPublisher.PublishAsync(new DocumentAdded(command.Id, command.FileName, command.FileArray, command.ExternalId), context);
        }
    }
}
