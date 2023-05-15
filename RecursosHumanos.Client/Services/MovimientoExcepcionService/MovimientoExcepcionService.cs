using RecursosHumanos.Client.Services.Http;
using RecursosHumanos.Client.Services.MovimientoExcepcionService;
using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Client.Services.MovimientoExcepcionService;

public class MovimientoExcepcionService : IMovimientoExcepcionService
{
    private readonly IRestClientService _client;

    public MovimientoExcepcionService(IRestClientService client)
    {
        _client = client;
    }

    public async Task<List<MovimientoExcepcion>> GetAll1y2()
    {
        return await _client.Get<List<MovimientoExcepcion>>("MovimientoExcepcion/1y2");
    }

    public async Task<List<MovimientoExcepcion>> GetAll3()
    {
        return await _client.Get<List<MovimientoExcepcion>>("MovimientoExcepcion/3");
    }
}
