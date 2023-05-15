using RecursosHumanos.Client.Services.Http;
using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Client.Services.AplicaIESSService;

public class AplicaIESSService : IAplicaIESSService
{

    private readonly IRestClientService _client;

    public AplicaIESSService(IRestClientService client)
    {
        _client = client;
    }

    public async Task<List<AplicaIESS>> GetAll()
    {
        return await _client.Get<List<AplicaIESS>>("AplicaIESS");
    }
}
