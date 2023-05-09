using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace RecursosHumanos.Api.Settings;

public static class SettingsExtension
{
    public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
        EcuasolSettings ecuasolSettings = new();
        configuration.Bind(EcuasolSettings.SectionName, ecuasolSettings);
        services.AddSingleton(Options.Create(ecuasolSettings));

        services.AddHttpClient("Ecuasol", client =>
        {
            client.BaseAddress = new Uri(ecuasolSettings.BaseUri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        });

        return services;
    }
}
