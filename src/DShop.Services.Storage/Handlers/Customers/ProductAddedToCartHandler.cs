using System.Linq;
using System.Threading.Tasks;
using DShop.Common.Handlers;
using DShop.Common.RabbitMq;
using DShop.Messages.Events.Customers;
using DShop.Services.Storage.Framework;
using DShop.Services.Storage.Models.Customers;
using DShop.Services.Storage.Repositories;
using DShop.Services.Storage.Services;

namespace DShop.Services.Storage.Handlers.Customers
{
    public class ProductAddedToCartHandler : IEventHandler<ProductAddedToCart>
    {
        private readonly ICache _cache;
        private readonly IProductsRepository _productsRepository;

        public ProductAddedToCartHandler(ICache cache,
            IProductsRepository productsRepository)
        {
            _cache = cache;
            _productsRepository = productsRepository;
        }

        public async Task HandleAsync(ProductAddedToCart @event, ICorrelationContext context)
        {
            var cart = await _cache.GetCartAsync(@event.CustomerId);
            var product = await _productsRepository.GetAsync(@event.ProductId);
            var item = cart.Items.SingleOrDefault(x => x.ProductId == @event.ProductId);
            if (item == null)
            {
                cart.Items.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    UnitPrice = product.Price,
                    Quantity = @event.Quantity
                });
            }
            else
            {
                item.Quantity += @event.Quantity;
            }
            await _cache.SetCartAsync(@event.CustomerId, cart);
        }
    }
}