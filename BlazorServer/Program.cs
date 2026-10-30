using API.Auth.Blazor.Server;
using API.Clients;
using BlazorServer.Components; 
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
    });
builder.Services.AddAuthorization();

builder.Services.AddScoped<BlazorServerAuthService>();

builder.Services.AddScoped<IAuthService>(proveedor =>
    proveedor.GetRequiredService<BlazorServerAuthService>());

builder.Services.AddScoped<AuthenticationStateProvider>(proveedor =>
    proveedor.GetRequiredService<BlazorServerAuthService>());

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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
