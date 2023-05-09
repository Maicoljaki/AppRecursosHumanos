using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using RecursosHumanos.Api.DTO.Ecuasol;
using RecursosHumanos.Api.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RecursosHumanos.Api.Auth;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public string Generate(EcuasolUser user)
    {
        var signingCredentials = new SigningCredentials(
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim("ruc", user.RucUsuario),
            new Claim("nombre", user.NombreUsuario),
            new Claim("emisor", user.NombreEmisor),
            new Claim("rol", user.Perfil),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    public Dictionary<string, string> GetClaims(string jwt)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Secret);

            tokenHandler.ValidateToken(jwt, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtSettings.Issuer,
                ValidAudience = _jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret))
            }, out SecurityToken validatedToken);

            var jwtTokenObject = (JwtSecurityToken)validatedToken;
            var claims = jwtTokenObject.Claims.ToDictionary(c => c.Type, c => c.Value);

            return claims;
        }
        catch (Exception)
        {
            return new Dictionary<string, string>();
        }
    }
}
