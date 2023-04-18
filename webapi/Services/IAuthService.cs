namespace webapi.Services;

public interface IAuthService
{
    public Task<bool> LogIn(string username, string password, int codigoEmisor);
}
