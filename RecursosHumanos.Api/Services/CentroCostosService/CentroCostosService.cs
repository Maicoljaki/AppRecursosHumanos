using ErrorOr;
using Newtonsoft.Json;
using RecursosHumanos.Api.DTO.Ecuasol;
using RecursosHumanos.Api.DTO.Errors;
using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Api.Services.CentroCostosService;

public class CentroCostosService : ICentroCostosService
{
    private HttpClient _httpClient;

    public CentroCostosService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient(Constants.HttpConstants.HttpClientName);
    }

    public async Task<ErrorOr<List<CentroCostos>>> GetAll()
    {
        var response = await _httpClient.GetAsync("Varios/CentroCostosSelect");

        if (response is null || !response.IsSuccessStatusCode)
        {
            return GeneralErrors.NotFound;
        }

        var jsonContent = await response.Content.ReadAsStringAsync();
        string contentString = JsonConvert.DeserializeObject<string>(jsonContent) ?? "";
        var centros = JsonConvert.DeserializeObject<List<EcuasolCentroCostos>>(contentString) ?? new();

        return centros.Select(c => new CentroCostos(c.Codigo, c.Nombre)).ToList();
    }

    public async Task<ErrorOr<CentroCostos>> Insert(int Codigo, string Nombre)
    {
        var response = await _httpClient.GetAsync($"Varios/CentroCostosInsert?codigocentrocostos={Codigo}&descripcioncentrocostos={Nombre}");

        if (response is null || !response.IsSuccessStatusCode)
        {
            return GeneralErrors.NotFound;
        }

        var jsonContent = await response.Content.ReadAsStringAsync();
        string contentString = JsonConvert.DeserializeObject<string>(jsonContent) ?? "";
        var centros = JsonConvert.DeserializeObject<List<EcuasolCentroCostos>>(contentString) ?? new();
        if (centros.Count == 0)
        {
            return AuthenticationErrors.InvalidCredentials;
        }
        return new CentroCostos(centros[0].Codigo, centros[0].Nombre);
    }

    public async Task<ErrorOr<CentroCostos>> Update(int Codigo, string Nombre)
    {
        var response = await _httpClient.GetAsync($"Varios/CentroCostosUpdate?codigocentrocostos={Codigo}&descripcioncentrocostos={Nombre}");

        if (response is null || !response.IsSuccessStatusCode)
        {
            return GeneralErrors.NotFound;
        }

        return new CentroCostos(Codigo, Nombre);
    }

    public async Task<ErrorOr<CentroCostos>> Delete(int Codigo, string Nombre)
    {
        var response = await _httpClient.GetAsync($"Varios/CentroCostosDelete?codigocentrocostos={Codigo}&descripcioncentrocostos={Nombre}");

        if (response is null || !response.IsSuccessStatusCode)
        {
            return GeneralErrors.NotFound;
        }

        return new CentroCostos(Codigo, Nombre);
    }
}
