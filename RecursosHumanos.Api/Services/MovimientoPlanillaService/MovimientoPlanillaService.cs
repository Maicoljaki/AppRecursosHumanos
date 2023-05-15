using ErrorOr;
using Newtonsoft.Json;
using RecursosHumanos.Api.DTO.Ecuasol;
using RecursosHumanos.Api.DTO.Errors;
using RecursosHumanos.Shared.Models;
using RecursosHumanos.Shared.Requests;

namespace RecursosHumanos.Api.Services.MovimientoPlanillaService;

public class MovimientoPlanillaService : IMovimientoPlanillaService
{
    private readonly HttpClient _httpClient;

    public MovimientoPlanillaService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient(Constants.HttpConstants.HttpClientName);
    }

    public async Task<ErrorOr<MovimientoPlanillaSimple>> Delete(DeleteMovimientoPlanillaRequest request)
    {
        var delete = $"codigomovimiento={request.CodigoConcepto}"
            + $"&descripcionomovimiento={request.Concepto}";

        var response = await _httpClient.GetAsync($"Varios/MovimeintoPlanillaDelete?{delete}");

        if (response is null || !response.IsSuccessStatusCode)
        {
            return GeneralErrors.NotFound;
        }

        return new MovimientoPlanillaSimple(request.CodigoConcepto, request.Concepto);
    }

    public async Task<ErrorOr<List<MovimientoPlanilla>>> GetAll()
    {
        var response = await _httpClient.GetAsync("Varios/MovimientoPlanillaSelect");

        if (response is null || !response.IsSuccessStatusCode)
        {
            return GeneralErrors.NotFound;
        }

        var jsonContent = await response.Content.ReadAsStringAsync();
        string contentString = JsonConvert.DeserializeObject<string>(jsonContent) ?? "";
        var centros = JsonConvert.DeserializeObject<List<EcuasolMovimientoPlanilla>>(contentString) ?? new();

        return centros.Select(c => new MovimientoPlanilla(
            c.CodigoConcepto,
            c.Concepto,
            c.Prioridad,
            c.TipoOperacion,
            c.Cuenta1,
            c.Cuenta2,
            c.Cuenta3,
            c.Cuenta4,
            c.MovimientoExcepcion1,
            c.MovimientoExcepcion2,
            c.MovimientoExcepcion3,
            c.AplicaIESS,
            c.AplicaImpRenta,
            c.EmpresaAfectaIess,
            c.Mensaje)).ToList();
    }

    public async Task<ErrorOr<MovimientoPlanillaSimple>> Update(UpdateMovimientoPlanillaRequest request)
    {
        var insertStr = $"codigoplanilla={request.CodigoConcepto}"
            + $"&conceptos={request.Concepto}"
            + $"&prioridad={request.Prioridad}"
            + $"&tipooperacion={request.CodigoTipoOperacion}"
            + $"&cuenta1={request.Cuenta1}"
            + $"&cuenta2={request.Cuenta2}"
            + $"&cuenta3={request.Cuenta3}"
            + $"&cuenta4={request.Cuenta4}"
            + $"&MovimientoExcepcion1={request.CodigoMovimientoExcepcion1}"
            + $"&MovimientoExcepcion2={request.CodigoMovimientoExcepcion2}"
            + $"&MovimientoExcepcion3={request.CodigoMovimientoExcepcion3}"
            + $"&Traba_Aplica_iess={request.CodigoAplicaIESS}"
            + $"&Traba_Proyecto_imp_renta={request.CodigoAplicaImpRenta}"
            + $"&Aplica_Proy_Renta=1"
            + $"&Empresa_Afecta_Iess={request.CodigoEmpresaAfectaIESS}";

        var response = await _httpClient.GetAsync($"Varios/MovimientoPlanillaUpdate?{insertStr}");

        if (response is null || !response.IsSuccessStatusCode)
        {
            return GeneralErrors.NotFound;
        }

        return new MovimientoPlanillaSimple(0, request.Concepto);
    }

    public async Task<ErrorOr<MovimientoPlanillaSimple>> Insert(InsertMovimientoPlanillaRequest request)
    {
        var insertStr = $"conceptos={request.Concepto}"
            + $"&prioridad={request.Prioridad}"
            + $"&tipooperacion={request.CodigoTipoOperacion}"
            + $"&cuenta1={request.Cuenta1}"
            + $"&cuenta2={request.Cuenta2}"
            + $"&cuenta3={request.Cuenta3}"
            + $"&cuenta4={request.Cuenta4}"
            + $"&MovimientoExcepcion1={request.CodigoMovimientoExcepcion1}"
            + $"&MovimientoExcepcion2={request.CodigoMovimientoExcepcion2}"
            + $"&MovimientoExcepcion3={request.CodigoMovimientoExcepcion3}"
            + $"&Traba_Aplica_iess={request.CodigoAplicaIESS}"
            + $"&Traba_Proyecto_imp_renta={request.CodigoAplicaImpRenta}"
            + $"&Aplica_Proy_Renta=0"
            + $"&Empresa_Afecta_Iess={request.CodigoEmpresaAfectaIESS}";

        var response = await _httpClient.GetAsync($"Varios/MovimientoPlanillaInsert?{insertStr}");

        if (response is null || !response.IsSuccessStatusCode)
        {
            return GeneralErrors.NotFound;
        }

        return new MovimientoPlanillaSimple(0, request.Concepto);
    }
}
