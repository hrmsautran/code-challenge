using Microsoft.AspNetCore.Mvc;

namespace TaxaDeJurosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaJurosController : ControllerBase
    {
        protected const double TAXA_DE_JUROS = 0.01;

        [HttpGet]
        public IActionResult ObterTaxaDeJuros()
        {
            return Ok(TAXA_DE_JUROS);
        }
    }
}