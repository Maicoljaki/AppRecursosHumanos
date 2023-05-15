using RecursosHumanos.Client.Services.Http;
using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Client.Services.AplicaImpuestoRentaService;

public class AplicaImpuestoRentaService : IAplicaImpuestoRentaService
{
    private readonly IRestClientService _client;

    public AplicaImpuestoRentaService(IRestClientService client)
    {
        _client = client;
    }

    public async Task<List<AplicaImpuestoRenta>> GetAll()
    {
        return await _client.Get<List<AplicaImpuestoRenta>>("AplicaImpuestoRenta");
    }
}
