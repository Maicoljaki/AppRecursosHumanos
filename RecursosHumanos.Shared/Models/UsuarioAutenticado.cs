namespace RecursosHumanos.Shared.Models;

public record UsuarioAutenticado(
    string Usuario,
    string Ruc,
    string JwtToken,
    Emisor Emisor,
    Perfil Perfil,
    Compania Compania,
    Cliente Cliente);