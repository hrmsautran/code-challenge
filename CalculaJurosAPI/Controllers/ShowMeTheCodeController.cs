using Microsoft.AspNetCore.Mvc;

namespace CalculaJurosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowMeTheCodeController : ControllerBase
    {
        private readonly string _githubRepository;

        public ShowMeTheCodeController()
        {
            _githubRepository = "https://github.com/hrmsautran/code-challenge";
        }

        /// <summary>
        /// Retorna a URL do repositório do projeto.
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this._githubRepository);
        }
    }
}
