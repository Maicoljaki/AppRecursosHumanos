using RecursosHumanos.App.Pages.Auth;
using RecursosHumanos.App.Services.Http;
using RecursosHumanos.Shared.Models;
using RecursosHumanos.Shared.Requests;

namespace RecursosHumanos.App.Services.Auth;

public class AuthenticationService : IAuthenticationService
{
    private IRestClientService _restClientService;

    public AuthenticationService(IRestClientService restClientService)
    {
        _restClientService = restClientService;
    }

    public async Task<UsuarioAutenticado> Login(LoginRequest login)
    {
        var usuario = await _restClientService.Post<UsuarioAutenticado, LoginRequest>("authentication/login", login);
        return usuario;
    }

    public async Task<Usuario?> GetFromJwt(JwtUserRequest request)
    {
        var usuario = await _restClientService.Post<Usuario, JwtUserRequest> ($"Authentication/getByJwt",request);
        return usuario;
    }
}
