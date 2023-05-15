using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Client.Services.TipoOperacionService;

public interface ITipoOperacionService
{
    public Task<List<TipoOperacion>> GetAll();
}
