using DShop.Common.Types;
using Microsoft.AspNetCore.Mvc;

namespace DShop.Services.Storage.Controllers
{
    [Route("[controller]")]
    public abstract class BaseController : Controller
    {
        protected IActionResult Single<T>(T model)
        {
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        protected IActionResult Collection<T>(PagedResult<T> pagedResult)
        {
            if (pagedResult == null)
            {
                return NotFound();
            }

            return Ok(pagedResult);
        }
    }
}