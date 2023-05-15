using ErrorOr;
using Newtonsoft.Json;
using RecursosHumanos.Api.DTO.Ecuasol;
using RecursosHumanos.Api.DTO.Errors;
using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Api.Services.EmisorService;

public class EmisorService : IEmisorService
{
    private HttpClient _httpClient;

    public EmisorService(IHttpClientFactory httpFactory)
    {
        _httpClient = httpFactory.CreateClient(Constants.HttpConstants.HttpClientName);
    }

    public async Task<ErrorOr<List<Emisor>>> GetAll()
    {
        var response = await _httpClient.GetAsync("Varios/GetEmisor");

        if (response is null || !response.IsSuccessStatusCode)
        {
            return GeneralErrors.NotFound;
        }

        var jsonContent = await response.Content.ReadAsStringAsync();
        string emisoresString = JsonConvert.DeserializeObject<string>(jsonContent) ?? "";
        var emisores = JsonConvert.DeserializeObject<List<EcuasolEmisor>>(emisoresString) ?? new();

        return emisores.Select(e => new Emisor(e.Codigo, e.NombreEmisor)).ToList();
    }
}
