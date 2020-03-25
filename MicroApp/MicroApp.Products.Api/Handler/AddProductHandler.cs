using MicroApp.Common.Handlers;
using MicroApp.Common.RabbitMq;
using MicroApp.Products.Api.Domain;
using MicroApp.Products.Api.Messages.Commands;
using MicroApp.Products.Api.Messages.Events;
using MicroApp.Products.Api.Repositories;
using System.Threading.Tasks;

namespace MicroApp.Products.Api.Handler
{
    public class AddProductHandler : ICommandHandler<AddProduct>
    {
        private readonly IBusPublisher _busPublisher;
        private readonly IProductRepository _productRepository;

        public AddProductHandler(IBusPublisher busPublisher, IProductRepository productRepository)
        {
            _busPublisher = busPublisher;
            _productRepository = productRepository;
        }
        public async Task HandleAsync(AddProduct command, ICorrelationContext context)
        {
            var product = new Product(command.Id, command.Name, command.Description, command.Price, command.CategoryId);
            await _productRepository.AddAsync(product);
            await _busPublisher.PublishAsync(new ProductAdded(command.Id, command.Name, command.Description, command.Price), context);
        }
    }
}
