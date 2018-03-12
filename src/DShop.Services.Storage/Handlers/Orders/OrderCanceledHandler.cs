using DShop.Common.Handlers;
using DShop.Common.RabbitMq;
using DShop.Messages.Events.Orders;
using DShop.Services.Storage.Repositories;
using System.Threading.Tasks;
using static DShop.Services.Storage.Models.Orders.Order;

namespace DShop.Services.Storage.Handlers.Orders
{
    public sealed class OrderCanceledHandler : IEventHandler<OrderCanceled>
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrderCanceledHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task HandleAsync(OrderCanceled @event, ICorrelationContext context)
        {
            var order = await _ordersRepository.GetAsync(@event.Id);
            order.Status = OrderStatus.Canceled;

            await _ordersRepository.UpdateAsync(order);
        }
    }
}
