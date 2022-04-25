namespace CalculaJurosAPI.Services
{
    public interface ITaxaDeJurosService
    {
        Task<decimal> GetAsync();
    }
}
