using System;
using System.Threading.Tasks;
using DShop.Services.Storage.Framework;
using DShop.Services.Storage.Models.Queries;
using DShop.Services.Storage.Repositories;
using DShop.Services.Storage.Services;
using Microsoft.AspNetCore.Mvc;

namespace DShop.Services.Storage.Controllers
{
    public class CartsController : BaseController
    {
        private readonly ICache _cache;

        public CartsController(ICache cache)
        {
            _cache = cache;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _cache.GetCartAsync(id));
    }
}