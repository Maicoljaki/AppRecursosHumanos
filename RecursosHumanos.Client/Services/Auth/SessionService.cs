using Blazored.LocalStorage;
namespace RecursosHumanos.Client.Services.Auth;

public class SessionService : ISessionService
{
    public static readonly string TokenString = "token";

    private ILocalStorageService _storage;

    public SessionService(ILocalStorageService storage)
    {
        _storage = storage;
    }

    public async Task<string?> GetJwtTokenAsync()
    {
        return await _storage.GetItemAsync<string>(TokenString);
    }

    public async Task SaveJwtToken(string token)
    {
        await _storage.SetItemAsync(TokenString, token);
    }

    public async Task RemoveJwtToken()
    {
        await _storage.RemoveItemAsync(TokenString);
    }
}
