using ErrorOr;
using Newtonsoft.Json;
using RecursosHumanos.Api.DTO.Ecuasol;
using RecursosHumanos.Api.DTO.Errors;
using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Api.Services.TipoOperacionService;

public class TipoOperacionService : ITipoOperacionService
{
    private readonly HttpClient _httpClient;

    public TipoOperacionService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient(Constants.HttpConstants.HttpClientName);
    }

    public async Task<ErrorOr<List<TipoOperacion>>> GetAll()
    {
        var response = await _httpClient.GetAsync("Varios/TipoOperacion");

        if (response is null || !response.IsSuccessStatusCode)
        {
            return GeneralErrors.NotFound;
        }

        var jsonContent = await response.Content.ReadAsStringAsync();
        string objString = JsonConvert.DeserializeObject<string>(jsonContent) ?? "";
        var objs = JsonConvert.DeserializeObject<List<EcuasolTipoOperacion>>(objString) ?? new();

        return objs.Select(e => new TipoOperacion(e.Codigo, e.Nombre)).ToList();
    }
}
