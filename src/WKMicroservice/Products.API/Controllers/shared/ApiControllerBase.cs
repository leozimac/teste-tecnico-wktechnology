using Microsoft.AspNetCore.Mvc;

namespace Products.API.Controllers.shared
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
    }
}
