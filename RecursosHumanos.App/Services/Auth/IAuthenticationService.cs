using RecursosHumanos.Shared.Models;
using RecursosHumanos.Shared.Requests;

namespace RecursosHumanos.App.Services.Auth;

public interface IAuthenticationService
{
    public Task<UsuarioAutenticado> Login(LoginRequest login);
    public Task<Usuario?> GetFromJwt(JwtUserRequest request);
}
