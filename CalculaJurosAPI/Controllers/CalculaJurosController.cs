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

        /// <summary>
        /// Retorna taxa de juros calculado.
        /// </summary>
        /// <param name="valorInicial">Valor inicial para o cálculo.</param>
        /// <param name="meses">Quantidade de meses para o cálculo.</param>
        /// <returns>Um valor decimal representando o cálculo, ex: 105.10</returns>
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

            var result = juros.Calcular().ToString("N2");

            return Ok(result);
        }
    }
}
