using Microsoft.AspNetCore.Mvc;

namespace TaxaJurosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaJurosController : ControllerBase
    {
        protected const double TAXA_DE_JUROS = 0.01;

        /// <summary>
        /// Retorna taxa de juros.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ObterTaxaDeJuros()
        {
            return Ok(TAXA_DE_JUROS);
        }
    }
}