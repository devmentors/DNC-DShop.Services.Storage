using DShop.Common.Types;
using Microsoft.AspNetCore.Mvc;

namespace DShop.Services.Storage.Controllers
{
    [Route("[controller]")]
    public abstract class BaseController : Controller
    {
        protected IActionResult OkOrNotFound<T>(T model)
        {
            if (model != null)
            {
                return Ok(model);
            }

            return NotFound();
        }

        protected IActionResult Collection<T>(PagedResult<T> pagedResult)
        {
            if (pagedResult == null)
            {
                return NotFound();
            }

            return Ok(pagedResult.Items);
        }
    }
}