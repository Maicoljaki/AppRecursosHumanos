using ErrorOr;

namespace RecursosHumanos.Api.DTO.Errors;

public static class AuthenticationErrors
{
    public static readonly string CodePrefix = "Auth.";
    public static readonly Error InvalidCredentials = Error.Validation(
        code: CodePrefix + "InvalidCredentials",
        description: "Invalid Credentials");
}
