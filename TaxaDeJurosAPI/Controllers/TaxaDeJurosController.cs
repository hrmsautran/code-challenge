using Microsoft.AspNetCore.Mvc;

namespace TaxaDeJurosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaDeJurosController : ControllerBase
    {
        protected const double TAXA_DE_JUROS = 0.01;

        [HttpGet(Name = "taxaJuros")]
        public IActionResult ObterTaxaDeJuros()
        {
            return Ok(TAXA_DE_JUROS);
        }
    }
}