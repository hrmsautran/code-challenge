using Microsoft.AspNetCore.Mvc;

namespace CalculaJurosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
