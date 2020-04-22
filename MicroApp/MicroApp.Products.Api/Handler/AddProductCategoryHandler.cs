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
    public class AddProductCategoryHandler : ICommandHandler<AddProductCategory>
    {
        private readonly IBusPublisher _busPublisher;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly ILogger<AddProductCategoryHandler> _logger;

        public AddProductCategoryHandler(IBusPublisher busPublisher, IProductCategoryRepository productCategoryRepository, ILogger<AddProductCategoryHandler> logger)
        {
            _busPublisher = busPublisher;
            _productCategoryRepository = productCategoryRepository;
            _logger = logger;
        }
        public async Task HandleAsync(AddProductCategory command, ICorrelationContext context)
        {
            _logger.LogInformation($"Adding a product category: name = {command.Name}' Id = '{command.Id}'");
            var productCategory = new ProductCategory(command.Id, command.Name);
            await _productCategoryRepository.AddAsync(productCategory);
            _logger.LogInformation($"Added a product category: name = {command.Name}' Id = '{command.Id}'");
            await _busPublisher.PublishAsync(new ProductCategoryAdded(command.Id, command.Name), context);
        }
    }
}
