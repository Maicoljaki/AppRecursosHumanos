using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Client.Services.AplicaIESSService;

public interface IAplicaIESSService
{
    public Task<List<AplicaIESS>> GetAll();
}
