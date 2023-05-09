using RecursosHumanos.App.Services.Storage;

namespace RecursosHumanos.App.Services.Auth;

public class SessionService : ISessionService
{
    private static readonly string TokenString = "token";

    private ILocalStorageService _storage;

    public SessionService(ILocalStorageService storage)
    {
        _storage = storage;
    }

    public async Task<string?> GetJwtTokenAsync()
    {
        return await _storage.GetAsync(TokenString);
    }

    public async Task SaveJwtToken(string token)
    {
        await _storage.SaveAsync(TokenString, token);
    }

    public async Task RemoveJwtToken()
    {
        await _storage.RemoveAsync(TokenString);
    }
}
