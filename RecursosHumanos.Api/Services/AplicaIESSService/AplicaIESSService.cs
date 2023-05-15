using ErrorOr;
using Newtonsoft.Json;
using RecursosHumanos.Api.DTO.Ecuasol;
using RecursosHumanos.Api.DTO.Errors;
using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Api.Services.AplicaIESSService;

public class AplicaIESSService : IAplicaIESSService
{
    private readonly HttpClient _httpClient;

    public AplicaIESSService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient(Constants.HttpConstants.HttpClientName);
    }

    public async Task<ErrorOr<List<AplicaIESS>>> GetAll()
    {
        var response = await _httpClient.GetAsync("Varios/TrabaAfectaIESS");

        if (response is null || !response.IsSuccessStatusCode)
        {
            return GeneralErrors.NotFound;
        }

        var jsonContent = await response.Content.ReadAsStringAsync();
        string contentString = JsonConvert.DeserializeObject<string>(jsonContent) ?? "";
        var obj = JsonConvert.DeserializeObject<List<EcuasolAplicaIESS>>(contentString) ?? new();

        return obj.Select(o => new AplicaIESS(o.Codigo, o.Nombre)).ToList();
    }
}
