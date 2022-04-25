using Microsoft.AspNetCore.Mvc;

namespace CalculaJurosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(decimal valorInicial, int meses)
        {
            var valorFinal = valorInicial * (decimal)Math.Pow(1 + 0.01, meses);
            return Ok(Math.Round(valorFinal, 2));
        }
    }
}
