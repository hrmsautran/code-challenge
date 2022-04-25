using CalculaJurosAPI.Models;
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
            var juros = new Juros(valorInicial, meses, 0.01);
            
            return Ok(juros.Calcular());
        }
    }
}
