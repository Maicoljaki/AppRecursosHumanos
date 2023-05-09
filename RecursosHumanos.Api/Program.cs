using RecursosHumanos.Api.Auth;
using RecursosHumanos.Api.Services.Authentication;
using RecursosHumanos.Api.Services.CentroCostosService;
using RecursosHumanos.Api.Services.EmisorService;
using RecursosHumanos.Api.Settings;

var builder = WebApplication.CreateBuilder(args);
{
    var configuration = builder.Configuration;
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddAuthentication();

    builder.Services
        .AddSettings(configuration)
        .AddAuth(configuration);

    builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
    builder.Services.AddScoped<IEmisorService, EmisorService>();
    builder.Services.AddScoped<ICentroCostosService, CentroCostosService>();

    builder.Services.AddCors(c =>
    {
        c.AddPolicy("MyPolicy", p =>
        {
            p.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
        });
    });
}

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.UseCors("MyPolicy");

    app.Run();
}