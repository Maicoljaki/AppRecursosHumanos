using RecursosHumanos.App.Services.Http;
using RecursosHumanos.Shared.Models;
using static MudBlazor.Colors;

namespace RecursosHumanos.App.Services.CentroCostosService;

public class CentroCostosService : ICentroCostosService
{
    private IRestClientService _restClientService;

    public CentroCostosService(IRestClientService restClientService)
    {
        _restClientService = restClientService;
    }

    public async Task<List<CentroCostos>> GetAll()
    {
        var centrosCosto = await _restClientService.Get<List<CentroCostos>>("centroCostos");
        return centrosCosto;
    }

    public async Task<CentroCostos> GetByCodigo(int Codigo)
    {
        var centrosCosto = await _restClientService.Get<CentroCostos>($"centroCostos/getByCodigo?codigo={Codigo}");
        return centrosCosto;
    }

    public async Task Insert(CentroCostos centroCostos)
    {
        await _restClientService.Post<CentroCostos, CentroCostos>($"centroCostos/insert", centroCostos);
    }

    public async Task Update(CentroCostos centroCostos)
    {
        await _restClientService.Post<CentroCostos, CentroCostos>($"centroCostos/update", centroCostos);
    }

    public async Task Delete(CentroCostos centroCostos)
    {
        await _restClientService.Delete("centroCostos/delete", centroCostos);
    }
}
