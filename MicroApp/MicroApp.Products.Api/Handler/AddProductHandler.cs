using MicroApp.Common.Handlers;
using MicroApp.Common.RabbitMq;
using MicroApp.Products.Api.Domain;
using MicroApp.Products.Api.Messages.Commands;
using MicroApp.Products.Api.Messages.Events;
using MicroApp.Products.Api.Repositories;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MicroApp.Products.Api.Handler
{
    public class AddProductHandler : ICommandHandler<AddProduct>
    {
        private readonly IBusPublisher _busPublisher;
        private readonly IProductRepository _productRepository;
        private readonly ILogger<AddProductHandler> _logger;

        public AddProductHandler(IBusPublisher busPublisher, IProductRepository productRepository, ILogger<AddProductHandler> logger)
        {
            _busPublisher = busPublisher;
            _productRepository = productRepository;
            _logger = logger;
        }
        public async Task HandleAsync(AddProduct command, ICorrelationContext context)
        {
            _logger.LogInformation($"Adding a product: name = {command.Name}' Id = '{command.Id}'");
            var product = new Product(command.Id, command.Name, command.Description, command.Price, command.CategoryId);
            await _productRepository.AddAsync(product);
            _logger.LogInformation($"Added a product: name = {command.Name}' Id = '{command.Id}'");
            await _busPublisher.PublishAsync(new ProductAdded(command.Id, command.Name, command.Description, command.Price, command.CategoryId), context);
        }
    }
}
