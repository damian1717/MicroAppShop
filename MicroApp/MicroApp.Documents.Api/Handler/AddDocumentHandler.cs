using MicroApp.Common.Handlers;
using MicroApp.Common.RabbitMq;
using MicroApp.Documents.Api.Domain;
using MicroApp.Documents.Api.Messages.Commands;
using MicroApp.Documents.Api.Messages.Events;
using MicroApp.Documents.Api.Repositories;
using System.Threading.Tasks;

namespace MicroApp.Documents.Api.Handler
{
    public class AddDocumentHandler: ICommandHandler<AddDocument>
    {
        private readonly IBusPublisher _busPublisher;
        private readonly IDocumentRepository _documentRepository;
        public AddDocumentHandler(IBusPublisher busPublisher, IDocumentRepository documentRepository)
        {
            _busPublisher = busPublisher;
            _documentRepository = documentRepository;
        }

        public async Task HandleAsync(AddDocument command, ICorrelationContext context)
        {
            var document = new Document(command.Id, command.FileName, command.FileArray, command.ExternalId);
            await _documentRepository.AddAsync(document);
            await _busPublisher.PublishAsync(new DocumentAdded(command.Id, command.FileName, command.FileArray, command.ExternalId), context);
        }
    }
}
