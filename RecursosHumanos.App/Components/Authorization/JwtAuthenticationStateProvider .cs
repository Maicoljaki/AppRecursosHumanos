using Microsoft.AspNetCore.Components.Authorization;
using RecursosHumanos.App.Services.Auth;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace RecursosHumanos.App.Components.Authorization;

public class JwtAuthenticationStateProvider : AuthenticationStateProvider
{
    private static readonly ClaimsPrincipal Anonymous = new();

    private ISessionService _sessionService;


    public JwtAuthenticationStateProvider(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return new AuthenticationState(Anonymous);
        var jwtToken = await _sessionService.GetJwtTokenAsync();
        if (string.IsNullOrEmpty(jwtToken))
        {
            return new AuthenticationState(Anonymous);
        }

        var principal = LoadJwtToken(jwtToken);
        return new AuthenticationState(principal);
    }

    private ClaimsPrincipal LoadJwtToken(string jwtToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.ReadJwtToken(jwtToken);
        var identity = new ClaimsIdentity(token.Claims, "jwt");
        var user = new ClaimsPrincipal(identity);
        return user;
    }
}
