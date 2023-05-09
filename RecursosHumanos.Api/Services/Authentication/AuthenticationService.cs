﻿using ErrorOr;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RecursosHumanos.Api.Auth;
using RecursosHumanos.Api.DTO.Ecuasol;
using RecursosHumanos.Api.DTO.Errors;
using RecursosHumanos.Shared.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace RecursosHumanos.Api.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private IHttpClientFactory _httpFactory;
    private IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IHttpClientFactory httpFactory, IJwtTokenGenerator jwtTokenGenerator)
    {
        _httpFactory = httpFactory;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<UsuarioAutenticado>> LogIn(string username, string password, int codigoEmisor)
    {
        using var client = _httpFactory.CreateClient("Ecuasol");
        var response = await client.GetAsync($"Usuarios?usuario={username}&password={password}");

        if (response is null || !response.IsSuccessStatusCode)
        {
            return GeneralErrors.NotFound;
        }

        var jsonContent = await response.Content.ReadAsStringAsync();
        if (jsonContent.Contains("error"))
        {
            return AuthenticationErrors.InvalidCredentials;
        }

        string usuariosEcuasolString = JsonConvert.DeserializeObject<string>(jsonContent) ?? "";
        var usuariosEcuasol = JsonConvert.DeserializeObject<List<EcuasolUser>>(usuariosEcuasolString) ?? new();
        foreach (var usuario in usuariosEcuasol)
        {
            if (usuario.Observacion == "INGRESO EXITOSO" && usuario.Emisor == codigoEmisor)
            {
                var token = _jwtTokenGenerator.Generate(usuario);
                return new UsuarioAutenticado(
                    usuario.NombreUsuario,
                    usuario.RucUsuario,
                    token,
                    new Emisor(usuario.Emisor, usuario.NombreEmisor),
                    new Perfil(usuario.CodigoPerfil, usuario.Perfil),
                    new Compania(usuario.Compania, usuario.NombreCompania),
                    new Cliente(usuario.UsuarioCliente));
            }
        }
        return AuthenticationErrors.InvalidCredentials;
    }

    public async Task<ErrorOr<Usuario>> GetByJwt(string jwtToken)
    {
        var claims = await Task.FromResult(_jwtTokenGenerator.GetClaims(jwtToken));
        if (claims.Count() == 0)
        {
            return GeneralErrors.NotFound;
        }

        var keys = new string[]{ "nombre", "ruc", "emisor" };
        foreach (var key in keys)
        {
            if (!claims.ContainsKey(key))
                return GeneralErrors.NotFound;
        }

        return new Usuario(claims["nombre"], claims["ruc"], claims["emisor"]);
    }
}
