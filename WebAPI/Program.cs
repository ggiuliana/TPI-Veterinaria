using Microsoft.EntityFrameworkCore;
using WebAPI;
using ServiciosApp;
using Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<VeterinariaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VeterinariaDB")));

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Dependency Injection
builder.Services.AddDbContext<VeterinariaContext>();

builder.Services.AddScoped<IDuenioRepository, DuenioRepository>();
builder.Services.AddScoped<IMascotaRepository, MascotaRepository>();
builder.Services.AddScoped<IVeterinarioRepository, VeterinarioRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IEstudioRepository, EstudioRepository>();
builder.Services.AddScoped<ITipoVacunaRepository, TipoVacunaRepository>();
builder.Services.AddScoped<IMedicamentoRepository, MedicamentoRepository>();

builder.Services.AddScoped<IDuenioService, DuenioService>();
builder.Services.AddScoped<IMascotaService, MascotaService>();
builder.Services.AddScoped<IVeterinarioService, VeterinarioService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IEstudioService, EstudioService>();
builder.Services.AddScoped<ITipoVacunaService, TipoVacunaService>();
builder.Services.AddScoped<IMedicamentoService, MedicamentoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

// Map endpoints
app.MapDuenioEndpoints();
app.MapMascotaEndpoints();
app.MapVeterinarioEndpoints();
app.MapUsuarioEndpoints();
app.MapEstudioEndpoints();
app.MapTipoVacunaEndpoints();
app.MapMedicamentoEndpoints();

app.Run();