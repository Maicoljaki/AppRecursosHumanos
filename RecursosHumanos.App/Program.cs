using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;
using RecursosHumanos.App.Services.Storage;
using RecursosHumanos.App.Services.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using RecursosHumanos.App.Components.Authorization;
using RecursosHumanos.App.Services.Http;
using RecursosHumanos.App.Data.Settings;
using RecursosHumanos.App.Services.EmisorService;
using RecursosHumanos.App.Services.Common;
using RecursosHumanos.App.Services.CentroCostosService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();

builder.Services.AddHttpClient("EcuasolApi", c =>
{
    EcuasolSettings settings = new();
    builder.Configuration.GetSection(EcuasolSettings.SectionName).Bind(settings);
    c.BaseAddress = new Uri(settings.BaseUri);
});

builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<IRestClientService, RestClientService>();
builder.Services.AddScoped<DialogMsgService>();

builder.Services.AddScoped<IEmisorService, EmisorService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ICentroCostosService, CentroCostosService>();

builder.Services.AddScoped<JwtAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(p => p.GetRequiredService<JwtAuthenticationStateProvider>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

// Authentication
app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
