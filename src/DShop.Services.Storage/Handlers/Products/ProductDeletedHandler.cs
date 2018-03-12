using DShop.Common.Handlers;
using DShop.Common.RabbitMq;
using DShop.Messages.Events.Products;
using DShop.Services.Storage.Repositories;
using System.Threading.Tasks;

namespace DShop.Services.Storage.Handlers.Products
{
    public sealed class ProductDeletedHandler : IEventHandler<ProductDeleted>
    {
        private readonly IProductsRepository _productsRepository;

        public ProductDeletedHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task HandleAsync(ProductDeleted @event, ICorrelationContext context)
        {
            await _productsRepository.DeleteAsync(@event.Id);
        }
    }
}
