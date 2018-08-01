using Microsoft.AspNetCore.Mvc;

namespace WebApi.Core2.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {

    }
}