﻿namespace RecursosHumanos.App.Services.Auth;

public interface ISessionService
{
    public Task<string?> GetJwtTokenAsync();
    public Task SaveJwtToken(string token);
    public Task RemoveJwtToken();
}
