using DShop.Common.Handlers;
using DShop.Common.RabbitMq;
using DShop.Messages.Events.Orders;
using DShop.Services.Storage.Repositories;
using DShop.Services.Storage.ServiceForwarders;
using System.Threading.Tasks;

namespace DShop.Services.Storage.Handlers.Orders
{
    public sealed class OrderCreatedHandler : IEventHandler<OrderCreated>
    {
        private readonly IOrdersService _ordersService;
        private readonly IOrdersRepository _ordersRepository;

        public OrderCreatedHandler(IOrdersService ordersService, IOrdersRepository ordersRepository)
        {
            _ordersService = ordersService;
            _ordersRepository = ordersRepository;
        }

        public async Task HandleAsync(OrderCreated @event, ICorrelationContext context)
        {
            var order = await _ordersService.GetByIdAsync(@event.Id);
            await _ordersRepository.CreateAsync(order);
        }
    }
}
