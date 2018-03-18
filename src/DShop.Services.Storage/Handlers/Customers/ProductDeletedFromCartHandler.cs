using System.Linq;
using System.Threading.Tasks;
using DShop.Common.Handlers;
using DShop.Common.RabbitMq;
using DShop.Messages.Events.Customers;
using DShop.Services.Storage.Framework;
using DShop.Services.Storage.Models.Customers;
using DShop.Services.Storage.Services;

namespace DShop.Services.Storage.Handlers.Customers
{
    public class ProductDeletedFromCartHandler : IEventHandler<ProductDeletedFromCart>
    {
        private readonly ICache _cache;

        public ProductDeletedFromCartHandler(ICache cache)
        {
            _cache = cache;
        }

        public async Task HandleAsync(ProductDeletedFromCart @event, ICorrelationContext context)
        {
            var cart = await _cache.GetCartAsync(@event.CustomerId);
            var item = cart.Items.SingleOrDefault(x => x.ProductId == @event.ProductId);
            if (item == null)
            {
                return;
            }
            cart.Items.Remove(item);
            await _cache.SetCartAsync(@event.CustomerId, cart);
        }
    }
}