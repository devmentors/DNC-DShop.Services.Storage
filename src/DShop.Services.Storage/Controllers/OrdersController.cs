using DShop.Services.Storage.Models.Orders;
using DShop.Services.Storage.Models.Queries;
using DShop.Services.Storage.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DShop.Services.Storage.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly ICustomersRepository _customersRepository;

        public OrdersController(
            IOrdersRepository ordersRepository, 
            IProductsRepository productsRepository, 
            ICustomersRepository customersRepository)
        {
            _ordersRepository = ordersRepository;
            _productsRepository = productsRepository;
            _customersRepository = customersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BrowseOrders query)
            => Collection(await _ordersRepository.BrowseAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var order = await _ordersRepository.GetAsync(id);
            var products = await _productsRepository.FindAsync(p => order.ProductIds.Contains(p.Id));
            var customer = await _customersRepository.GetAsync(order.CustomerId);

            var orderDetails = new OrderDetails
            {
                Order = order,
                Products = products,
                Customer = customer
            };

            return Single(orderDetails);
        }
    }
}
