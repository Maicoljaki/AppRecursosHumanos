using ErrorOr;
using Newtonsoft.Json;
using RecursosHumanos.Api.DTO.Ecuasol;
using RecursosHumanos.Api.DTO.Errors;
using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Api.Services.EmisorService;

public class EmisorService : IEmisorService
{
    private IHttpClientFactory _httpFactory;

    public EmisorService(IHttpClientFactory httpFactory)
    {
        _httpFactory = httpFactory;
    }

    public async Task<ErrorOr<List<Emisor>>> GetAll()
    {
        using var client = _httpFactory.CreateClient("Ecuasol");
        var response = await client.GetAsync("Varios/GetEmisor");

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
