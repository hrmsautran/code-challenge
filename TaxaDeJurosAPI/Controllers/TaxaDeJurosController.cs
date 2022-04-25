using Microsoft.AspNetCore.Mvc;

namespace TaxaDeJurosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaDeJurosController : ControllerBase
    {
        [HttpGet(Name = "taxaJuros")]
        public IActionResult ObterTaxaDeJuros()
        {
            return Ok(1);
        }
    }
}