using Microsoft.AspNetCore.Mvc;

namespace DShop.Services.Storage.Controllers
{
    [Route("")]
    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Get() => Ok("DShop Storage Service");
    }
}