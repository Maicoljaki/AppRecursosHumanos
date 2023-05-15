using RecursosHumanos.Client.Services.Http;
using RecursosHumanos.Shared.Models;
using RecursosHumanos.Shared.Requests;

namespace RecursosHumanos.Client.Services.MovimientoPlanillaService;

public class MovimientoPlanillaService : IMovimientoPlanillaService
{
    private readonly IRestClientService _client;

    public MovimientoPlanillaService(IRestClientService client)
    {
        _client = client;
    }

    public async Task Delete(DeleteMovimientoPlanillaRequest item)
    {
        await _client.Delete("MovimientoPlanilla/delete", item);
    }

    public async Task<List<MovimientoPlanilla>> GetAll()
    {
        return await _client.Get<List<MovimientoPlanilla>>("MovimientoPlanilla");
    }

    public async Task<MovimientoPlanilla> GetByCodigoConcepto(int codigoConcepto)
    {
        return await _client.Get<MovimientoPlanilla>($"MovimientoPlanilla/getByCodigoConcepto?codigoConcepto={codigoConcepto}");
    }

    public async Task Insert(InsertMovimientoPlanillaRequest request)
    {
        await _client.Post("MovimientoPlanilla/insert", request);
    }

    public async Task Update(UpdateMovimientoPlanillaRequest request)
    {
        await _client.Put("MovimientoPlanilla/update", request);
    }
}
