using WebAPI;
using ServiciosApp;
using Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Dependency Injection
builder.Services.AddScoped<IDuenioRepository, DuenioRepository>();
builder.Services.AddScoped<IDuenioService, DuenioService>();
builder.Services.AddScoped<IMascotaRepository, MascotaRepository>();
builder.Services.AddScoped<IMascotaService, MascotaService>();
builder.Services.AddScoped<IVeterinarioRepository, VeterinarioRepository>();
builder.Services.AddScoped<IVeterinarioService, VeterinarioService>();

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

app.Run();