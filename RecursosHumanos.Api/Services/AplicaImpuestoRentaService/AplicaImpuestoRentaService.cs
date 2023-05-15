using ErrorOr;
using Newtonsoft.Json;
using RecursosHumanos.Api.DTO.Ecuasol;
using RecursosHumanos.Api.DTO.Errors;
using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Api.Services.AplicaImpuestoRentaService;

public class AplicaImpuestoRentaService : IAplicaImpuestoRentaService
{
    private readonly HttpClient _httpClient;

    public AplicaImpuestoRentaService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient(Constants.HttpConstants.HttpClientName);
    }

    public async Task<ErrorOr<List<AplicaImpuestoRenta>>> GetAll()
    {
        var response = await _httpClient.GetAsync("Varios/TrabAfecImpuestoRenta");

        if (response is null || !response.IsSuccessStatusCode)
        {
            return GeneralErrors.NotFound;
        }

        var jsonContent = await response.Content.ReadAsStringAsync();
        string contentString = JsonConvert.DeserializeObject<string>(jsonContent) ?? "";
        var obj = JsonConvert.DeserializeObject<List<EcuasolAplicaImpuestoRenta>>(contentString) ?? new();

        return obj.Select(o => new AplicaImpuestoRenta(o.Codigo, o.Nombre)).ToList();
    }
}