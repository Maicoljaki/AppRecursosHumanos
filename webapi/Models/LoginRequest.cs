namespace webapi.Models;

public record LoginRequest(string usuario, string password, int codigoEmisor);
