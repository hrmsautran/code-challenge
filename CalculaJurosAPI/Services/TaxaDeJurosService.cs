using Newtonsoft.Json;

namespace CalculaJurosAPI.Services
{
    public class TaxaDeJurosService : ITaxaDeJurosService
    {
        private readonly string _baseUrl;
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public TaxaDeJurosService(HttpClient client, IConfiguration configuration)
        {
            this._client = client;
            this._configuration = configuration;
            this._baseUrl = _configuration.GetValue<string>("API_URL");
        }

        public async Task<decimal> GetAsync()
        {
            var httpResponse = await _client.GetAsync(_baseUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Não foi possível buscar a taxa de juros.");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var taxa = JsonConvert.DeserializeObject<decimal>(content);

            return taxa;
        }
    }
}
