using System.Threading.Tasks;
using DShop.Common.Handlers;
using DShop.Common.RabbitMq;
using DShop.Messages.Events.Customers;
using DShop.Services.Storage.Framework;
using DShop.Services.Storage.Models.Customers;
using DShop.Services.Storage.Repositories;
using DShop.Services.Storage.ServiceForwarders;
using DShop.Services.Storage.Services;

namespace DShop.Services.Storage.Handlers.Customers
{
    public class CustomerCreatedHandler : IEventHandler<CustomerCreated>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly ICustomersService _customersService;
        private readonly ICache _cache;
        
        public CustomerCreatedHandler(ICustomersRepository customersRepository,
            ICustomersService customersService,
            ICache cache)
        {
            _customersRepository = customersRepository;
            _customersService = customersService;
            _cache = cache;
        }

        public async Task HandleAsync(CustomerCreated @event, ICorrelationContext context)
        {
            var customer = await _customersService.GetByIdAsync(@event.Id);
            await _customersRepository.CreateAsync(customer);
            await _cache.SetCartAsync(@event.Id, new Cart());
        }
    }
}