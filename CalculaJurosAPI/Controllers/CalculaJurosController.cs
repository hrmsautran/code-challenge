using CalculaJurosAPI.Models;
using CalculaJurosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculaJurosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ITaxaDeJurosService _taxaService;

        public CalculaJurosController(ITaxaDeJurosService taxaService)
        {
            _taxaService = taxaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(decimal valorInicial, int meses)
        {
            double taxa;
            try
            {
                taxa = await _taxaService.GetAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var juros = new Juros(valorInicial, meses, taxa);

            return Ok(juros.Calcular());
        }
    }
}
