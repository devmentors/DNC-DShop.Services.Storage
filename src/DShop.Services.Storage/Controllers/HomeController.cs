using Microsoft.AspNetCore.Mvc;

namespace DShop.Services.Storage.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get() => Ok("DShop Storage Service");
    }
}