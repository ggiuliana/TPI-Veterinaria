using API.Auth.Blazor.Server;
using API.Clients;
using BlazorServer.Components; 
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
    });
builder.Services.AddAuthorization();

builder.Services.AddScoped<AuthenticationStateProvider, BlazorServerAuthService>();

//borrar
//builder.Services.AddScoped<IAuthService, BlazorServerAuthService>();

builder.Services.AddScoped<IAuthService>(sp =>
    (IAuthService)sp.GetRequiredService<AuthenticationStateProvider>());

builder.Services.AddRadzenComponents();

builder.Services.AddScoped<AuthApiClient>();
builder.Services.AddScoped<VeterinarioClient>();
builder.Services.AddScoped<UsuarioClient>();
builder.Services.AddScoped<EstudioClient>();
builder.Services.AddScoped<TurnoClient>();
builder.Services.AddScoped<ConsultaClient>();
builder.Services.AddScoped<MedicamentoClient>();
builder.Services.AddScoped<MascotaClient>();
builder.Services.AddScoped<TipoVacunaClient>();
builder.Services.AddScoped<Radzen.DialogService>();
builder.Services.AddScoped<Radzen.NotificationService>();
builder.Services.AddScoped<Radzen.TooltipService>();
builder.Services.AddScoped<Radzen.ContextMenuService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

//borrar
//app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
