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

        public string Get()
        {
            return this._githubRepository;
        }
    }
}
