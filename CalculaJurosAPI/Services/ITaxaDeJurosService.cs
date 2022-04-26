namespace CalculaJurosAPI.Services
{
    public interface ITaxaDeJurosService
    {
        Task<double> GetAsync();
    }
}
