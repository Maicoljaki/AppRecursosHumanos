using ErrorOr;
using Newtonsoft.Json;
using RecursosHumanos.Api.DTO.Ecuasol;
using RecursosHumanos.Api.DTO.Errors;
using RecursosHumanos.Shared.Models;
using System.Net.Http;

namespace RecursosHumanos.Api.Services.MovimientoExcepcionService;

public class MovimientoExcepcionService : IMovimientoExcepcionService
{
    private readonly HttpClient _httpClient;

    public MovimientoExcepcionService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient(Constants.HttpConstants.HttpClientName);
    }

    public async Task<ErrorOr<List<MovimientoExcepcion>>> GetAll1y2()
    {
        var response = await _httpClient.GetAsync("Varios/MovimientosExcepcion1y2");

        if (response is null || !response.IsSuccessStatusCode)
        {
            return GeneralErrors.NotFound;
        }

        var jsonContent = await response.Content.ReadAsStringAsync();
        string stringObj = JsonConvert.DeserializeObject<string>(jsonContent) ?? "";
        var objs = JsonConvert.DeserializeObject<List<EcuasolMovimientoExcepcion>>(stringObj) ?? new();

        return objs.Select(e => new MovimientoExcepcion(e.Codigo, e.Nombre)).ToList();
    }

    public async Task<ErrorOr<List<MovimientoExcepcion>>> GetAll3()
    {
        var response = await _httpClient.GetAsync("Varios/MovimientosExcepcion3");

        if (response is null || !response.IsSuccessStatusCode)
        {
            return GeneralErrors.NotFound;
        }

        var jsonContent = await response.Content.ReadAsStringAsync();
        string stringObj = JsonConvert.DeserializeObject<string>(jsonContent) ?? "";
        var objs = JsonConvert.DeserializeObject<List<EcuasolMovimientoExcepcion>>(stringObj) ?? new();

        return objs.Select(e => new MovimientoExcepcion(e.Codigo, e.Nombre)).ToList();
    }
}
