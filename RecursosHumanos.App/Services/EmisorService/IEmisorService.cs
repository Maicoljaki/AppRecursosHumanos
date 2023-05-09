using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.App.Services.EmisorService;

public interface IEmisorService
{
    public Task<List<Emisor>> GetAll();
}
