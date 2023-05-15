using RecursosHumanos.Client.Services.Http;
using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Client.Services.TipoOperacionService;

public class TipoOperacionService : ITipoOperacionService
{
    private readonly IRestClientService _client;

    public TipoOperacionService(IRestClientService client)
    {
        _client = client;
    }

    public async Task<List<TipoOperacion>> GetAll()
    {
        return await _client.Get<List<TipoOperacion>>("TipoOperacion");
    }
}
