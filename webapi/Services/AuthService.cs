using Newtonsoft.Json;
using webapi.Models;

namespace webapi.Services;

public class AuthService : IAuthService
{
    private IHttpClientFactory _httpFactory;

    public AuthService(IHttpClientFactory httpFactory)
    {
        _httpFactory = httpFactory;
    }

    public async Task<bool> LogIn(string username, string password, int codigoEmisor)
    {
        using var client = _httpFactory.CreateClient("Ecuasol");
        var response = await client.GetAsync($"Usuarios?usuario={username}&password={password}");

        if (response is null || !response.IsSuccessStatusCode)
        {
            throw new Exception("Credenciales Incorrectas");
        }

        var jsonContent = await response.Content.ReadAsStringAsync();
        if (jsonContent == "\"\\\"error\\\"\"")
        {
            throw new Exception("Credenciales Incorrectas");
        }
        string usuariosEcuasolString = JsonConvert.DeserializeObject<string>(jsonContent) ?? "";
        var usuariosEcuasol = JsonConvert.DeserializeObject<List<EcuasolUser>>(usuariosEcuasolString) ?? new();
        foreach (var usuario in usuariosEcuasol)
        {
            if (usuario.Emisor == codigoEmisor)
            {
                return true;
            }
        }
        throw new Exception("Credenciales Incorrectas");

    }
}
