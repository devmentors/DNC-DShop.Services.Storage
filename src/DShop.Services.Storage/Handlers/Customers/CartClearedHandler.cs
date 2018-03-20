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
    public class CartClearedHandler : IEventHandler<CartCleared>
    {
        private readonly ICache _cache;

        public CartClearedHandler(ICache cache)
        {
            _cache = cache;
        }

        public async Task HandleAsync(CartCleared @event, ICorrelationContext context)
        {
            await _cache.ClearCartAsync(@event.CustomerId);
        }
    }
}