using RecursosHumanos.Api.DTO.Ecuasol;

namespace RecursosHumanos.Api.Auth;

public interface IJwtTokenGenerator
{
    public string Generate(EcuasolUser user);

    public Dictionary<string, string> GetClaims(string jwt);
}
