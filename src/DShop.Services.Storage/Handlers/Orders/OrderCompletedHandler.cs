using DShop.Common.Handlers;
using DShop.Common.RabbitMq;
using DShop.Messages.Events.Orders;
using DShop.Services.Storage.Repositories;
using System.Threading.Tasks;
using static DShop.Services.Storage.Models.Orders.Order;

namespace DShop.Services.Storage.Handlers.Orders
{
    public sealed class OrderCompletedHandler : IEventHandler<OrderCompleted>
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrderCompletedHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task HandleAsync(OrderCompleted @event, ICorrelationContext context)
        {
            var order = await _ordersRepository.GetAsync(@event.RequestId);
            order.Status = OrderStatus.Completed;

            await _ordersRepository.UpdateAsync(order);
        }
    }
}
