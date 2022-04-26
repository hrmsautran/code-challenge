using Newtonsoft.Json;

namespace CalculaJurosAPI.Services
{
    public class TaxaDeJurosService : ITaxaDeJurosService
    {
        readonly IHttpClientFactory _httpClientFactory;

        public TaxaDeJurosService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<double> GetAsync()
        {
            using var httpClient = _httpClientFactory.CreateClient("apiTaxaDeJuros");

            var result = await httpClient.GetAsync("taxaJuros");

            if (!result.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Não foi possível buscar a taxa de juros.");
            }

            var content = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<double>(content);
        }
    }
}
