using Microsoft.AspNetCore.Components.Authorization;
using RecursosHumanos.Client.Services.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace RecursosHumanos.Client.Components.Authorization;

public class JwtAuthenticationStateProvider : AuthenticationStateProvider
{
    private static readonly ClaimsPrincipal Anonymous = new ClaimsPrincipal(new ClaimsIdentity());

    private HttpClient _httpClient;
    private ISessionService _sessionService;

    public JwtAuthenticationStateProvider(ISessionService sessionService, IHttpClientFactory httpClientFactory)
    {
        _sessionService = sessionService ?? throw new ArgumentNullException(nameof(sessionService));
        _httpClient = httpClientFactory.CreateClient(Constants.HttpConstants.HttpClientName);
    }

    public async Task StateChangedAsync()
    {
        var authState = Task.FromResult(await GetAuthenticationStateAsync());
        NotifyAuthenticationStateChanged(authState);

    }

    public void MarkUserAsLoggedOut()
    {
        var authState = Task.FromResult(new AuthenticationState(Anonymous));
        NotifyAuthenticationStateChanged(authState);
    }

    public async Task<ClaimsPrincipal> GetAuthenticationStateProviderUserAsync()
    {
        var state = await GetAuthenticationStateAsync();
        var authenticationStateProviderUser = state.User;
        return authenticationStateProviderUser;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var savedToken = await _sessionService.GetJwtTokenAsync();
        if (string.IsNullOrWhiteSpace(savedToken))
        {
            return new AuthenticationState(Anonymous);
        }

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", savedToken);
        var state = new AuthenticationState(LoadJwtToken(savedToken));
        return state;
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
