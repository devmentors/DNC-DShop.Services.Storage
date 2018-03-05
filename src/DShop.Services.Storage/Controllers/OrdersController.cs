using DShop.Services.Storage.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public async Task<IActionResult> GetAsync([FromQuery] Guid id)
        {
            var order = await _ordersRepository.GetAsync(id);

            //TODO

            return Ok();
        }
    }
}
