using DShop.Common.Handlers;
using DShop.Common.RabbitMq;
using DShop.Messages.Events.Orders;
using DShop.Services.Storage.Framework;
using DShop.Services.Storage.Repositories;
using DShop.Services.Storage.Services;
using System.Threading.Tasks;
using static DShop.Services.Storage.Models.Orders.Order;

namespace DShop.Services.Storage.Handlers.Orders
{
    public sealed class OrderCompletedHandler : IEventHandler<OrderCompleted>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ICache _cache;

        public OrderCompletedHandler(IOrdersRepository ordersRepository, ICache cache)
        {
            _ordersRepository = ordersRepository;
            _cache = cache;
        }

        public async Task HandleAsync(OrderCompleted @event, ICorrelationContext context)
        {
            var order = await _ordersRepository.GetAsync(@event.Id);
            order.Status = OrderStatus.Completed;

            await _ordersRepository.UpdateAsync(order);
            await _cache.ClearCartAsync(order.CustomerId);
        }
    }
}
