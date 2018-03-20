using System;
using System.Threading.Tasks;
using DShop.Common.Types;
using DShop.Services.Storage.Models.Products;
using DShop.Services.Storage.Models.Queries;
using DShop.Services.Storage.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DShop.Services.Storage.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(BrowseProducts query)
            => Collection(await _productsRepository.BrowseAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _productsRepository.GetAsync(id));
    }
}