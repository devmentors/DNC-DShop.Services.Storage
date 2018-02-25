using System.Threading.Tasks;
using DShop.Common.Handlers;
using DShop.Common.RabbitMq;
using DShop.Messages.Events.Customers;
using DShop.Services.Storage.Repositories;
using DShop.Services.Storage.ServiceForwarders;

namespace DShop.Services.Storage.Handlers.Customers
{
    public class CustomerCreatedHandler : IEventHandler<CustomerCreated>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly ICustomersService _customersService;
        public CustomerCreatedHandler(ICustomersRepository customersRepository,
            ICustomersService customersService)
        {
            _customersRepository = customersRepository;
            _customersService = customersService;
        }

        public async Task HandleAsync(CustomerCreated @event, ICorrelationContext context)
        {
            var customer = await _customersService.GetByIdAsync(@event.UserId);
            await _customersRepository.CreateAsync(customer);
        }
    }
}