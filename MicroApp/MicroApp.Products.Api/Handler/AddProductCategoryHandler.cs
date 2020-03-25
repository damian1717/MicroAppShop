using MicroApp.Common.Handlers;
using MicroApp.Common.RabbitMq;
using MicroApp.Products.Api.Domain;
using MicroApp.Products.Api.Messages.Commands;
using MicroApp.Products.Api.Messages.Events;
using MicroApp.Products.Api.Repositories;
using System.Threading.Tasks;

namespace MicroApp.Products.Api.Handler
{
    public class AddProductCategoryHandler : ICommandHandler<AddProductCategory>
    {
        private readonly IBusPublisher _busPublisher;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public AddProductCategoryHandler(IBusPublisher busPublisher, IProductCategoryRepository productCategoryRepository)
        {
            _busPublisher = busPublisher;
            _productCategoryRepository = productCategoryRepository;
        }
        public async Task HandleAsync(AddProductCategory command, ICorrelationContext context)
        {
            var productCategory = new ProductCategory(command.Id, command.Name);
            await _productCategoryRepository.AddAsync(productCategory);
            await _busPublisher.PublishAsync(new ProductCategoryAdded(command.Id, command.Name), context);
        }
    }
}
