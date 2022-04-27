using Newtonsoft.Json;

namespace CalculaJurosAPI.Services
{
    public class TaxaDeJurosService : ITaxaDeJurosService
    {
        readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger _logger;

        public TaxaDeJurosService(IHttpClientFactory httpClientFactory, ILogger<TaxaDeJurosService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<double> GetAsync()
        {
            using var httpClient = _httpClientFactory.CreateClient("apiTaxaDeJuros");

            try
            {
                var result = await httpClient.GetAsync("taxaJuros");

                if (!result.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Erro ao recuperar taxa de juros.");
                    throw new HttpRequestException("Não foi possível calcular os juros, favor tentar novamente.");
                }

                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<double>(content);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Erro ao se conectar a API taxa de juros! Error: {ex.Message}");
                throw new Exception("Não foi possível calcular os juros, favor tentar novamente.");
            }
        }
    }
}
