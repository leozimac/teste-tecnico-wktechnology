using Microsoft.AspNetCore.Mvc;

namespace Categories.API.Controllers.shared
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
    }
}
