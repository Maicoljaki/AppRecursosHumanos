using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Client.Services.EmisorService;

public interface IEmisorService
{
    public Task<List<Emisor>> GetAll();
}
