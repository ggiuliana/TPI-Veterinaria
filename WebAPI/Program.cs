using Microsoft.EntityFrameworkCore;
using WebAPI;
using ServiciosApp;
using Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using API.Clients;
using API.Auth.Blazor.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header. Escribí 'Bearer ' seguido de tu token.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer" }
        },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddHttpLogging(o => { });

builder.Services.AddDbContext<VeterinariaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VeterinariaDB")));

builder.Services.AddScoped<IDuenioRepository, DuenioRepository>();
builder.Services.AddScoped<IMascotaRepository, MascotaRepository>();
builder.Services.AddScoped<IVeterinarioRepository, VeterinarioRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IEstudioRepository, EstudioRepository>();
builder.Services.AddScoped<ITipoVacunaRepository, TipoVacunaRepository>();
builder.Services.AddScoped<IMedicamentoRepository, MedicamentoRepository>();
builder.Services.AddScoped<IGrupoPermisoRepository, GrupoPermisoRepository>();
builder.Services.AddScoped<ITurnoRepository, TurnoRepository>();
builder.Services.AddScoped<IConsultaRepository, ConsultaRepository>();
builder.Services.AddScoped<IMedicamentoConsultaRepository, MedicamentoConsultaRepository>();

builder.Services.AddScoped<IDuenioService, DuenioService>();
builder.Services.AddScoped<IMascotaService, MascotaService>();
builder.Services.AddScoped<IVeterinarioService, VeterinarioService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IEstudioService, EstudioService>();
builder.Services.AddScoped<ITipoVacunaService, TipoVacunaService>();
builder.Services.AddScoped<IMedicamentoService, MedicamentoService>();
builder.Services.AddScoped<ITurnoService, TurnoService>();
builder.Services.AddScoped<IConsultaService, ConsultaService>();
builder.Services.AddScoped<IMedicamentoConsultaService, MedicamentoConsultaService>();

builder.Services.AddScoped<IAuthService, BlazorServerAuthService>();

builder.Services.AddScoped<AuthService>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHttpLogging(o => { });

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];
var issuer = jwtSettings["Issuer"];
var audience = jwtSettings["Audience"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = issuer,
            ValidateAudience = true,
            ValidAudience = audience,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!)),
            ClockSkew = TimeSpan.Zero
        };

        options.Events = new JwtBearerEvents
        {
            OnChallenge = async context =>
            {
                context.HandleResponse();

                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync("{\"mensaje\": \"Token requerido\"}");
            },

            OnForbidden = async context =>
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync("{\"mensaje\": \"Permisos Insuficientes\"}");
            }
        };
    });

builder.Services.AddAuthorization(options =>
{
    // Políticas para Estudios
    options.AddPolicy("EstudiosLeer", policy => policy.RequireClaim("permission", "estudios.leer"));
    options.AddPolicy("EstudiosAgregar", policy => policy.RequireClaim("permission", "estudios.agregar"));
    options.AddPolicy("EstudiosActualizar", policy => policy.RequireClaim("permission", "estudios.actualizar"));
    options.AddPolicy("EstudiosEliminar", policy => policy.RequireClaim("permission", "estudios.eliminar"));

    // Políticas para Medicamentos
    options.AddPolicy("MedicamentosLeer", policy => policy.RequireClaim("permission", "medicamentos.leer"));
    options.AddPolicy("MedicamentosAgregar", policy => policy.RequireClaim("permission", "medicamentos.agregar"));
    options.AddPolicy("MedicamentosActualizar", policy => policy.RequireClaim("permission", "medicamentos.actualizar"));
    options.AddPolicy("MedicamentosEliminar", policy => policy.RequireClaim("permission", "medicamentos.eliminar"));

    // Políticas para Duenios
    options.AddPolicy("DueniosLeer", policy => policy.RequireClaim("permission", "duenios.leer"));
    options.AddPolicy("DueniosAgregar", policy => policy.RequireClaim("permission", "duenios.agregar"));
    options.AddPolicy("DueniosActualizar", policy => policy.RequireClaim("permission", "duenios.actualizar"));
    options.AddPolicy("DueniosEliminar", policy => policy.RequireClaim("permission", "duenios.eliminar"));

    // Políticas para Consultas
    options.AddPolicy("ConsultasLeer", policy => policy.RequireClaim("permission", "consultas.leer"));
    options.AddPolicy("ConsultasAgregar", policy => policy.RequireClaim("permission", "consultas.agregar"));
    options.AddPolicy("ConsultasActualizar", policy => policy.RequireClaim("permission", "consultas.actualizar"));
    options.AddPolicy("ConsultasEliminar", policy => policy.RequireClaim("permission", "consultas.eliminar"));

    // Políticas para Mascotas
    options.AddPolicy("MascotasLeer", policy => policy.RequireClaim("permission", "mascotas.leer"));
    options.AddPolicy("MascotasAgregar", policy => policy.RequireClaim("permission", "mascotas.agregar"));
    options.AddPolicy("MascotasActualizar", policy => policy.RequireClaim("permission", "mascotas.actualizar"));
    options.AddPolicy("MascotasEliminar", policy => policy.RequireClaim("permission", "mascotas.eliminar"));

    // Políticas para TipoVacunas
    options.AddPolicy("TipoVacunasLeer", policy => policy.RequireClaim("permission", "tipos vacunas.leer"));
    options.AddPolicy("TipoVacunasAgregar", policy => policy.RequireClaim("permission", "tipos vacunas.agregar"));
    options.AddPolicy("TipoVacunasActualizar", policy => policy.RequireClaim("permission", "tipos vacunas.actualizar"));
    options.AddPolicy("TipoVacunasEliminar", policy => policy.RequireClaim("permission", "tipos vacunas.eliminar"));

    // Políticas para Turnos
    options.AddPolicy("TurnosLeer", policy => policy.RequireClaim("permission", "turnos.leer"));
    options.AddPolicy("TurnosAgregar", policy => policy.RequireClaim("permission", "turnos.agregar"));
    options.AddPolicy("TurnosActualizar", policy => policy.RequireClaim("permission", "turnos.actualizar"));
    options.AddPolicy("TurnosEliminar", policy => policy.RequireClaim("permission", "turnos.eliminar"));

    // Políticas para Veterinarios
    options.AddPolicy("VeterinariosLeer", policy => policy.RequireClaim("permission", "veterinarios.leer"));
    options.AddPolicy("VeterinariosAgregar", policy => policy.RequireClaim("permission", "veterinarios.agregar"));
    options.AddPolicy("VeterinariosActualizar", policy => policy.RequireClaim("permission", "veterinarios.actualizar"));
    options.AddPolicy("VeterinariosEliminar", policy => policy.RequireClaim("permission", "veterinarios.eliminar"));

    // Políticas para Usuarios
    options.AddPolicy("UsuariosLeer", policy => policy.RequireClaim("permission", "usuarios.leer"));
    options.AddPolicy("UsuariosAgregar", policy => policy.RequireClaim("permission", "usuarios.agregar"));
    options.AddPolicy("UsuariosActualizar", policy => policy.RequireClaim("permission", "usuarios.actualizar"));
    options.AddPolicy("UsuariosEliminar", policy => policy.RequireClaim("permission", "usuarios.eliminar"));

    // Fallback: Requerir autenticación para endpoints no especificados
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorWasm",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

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
app.UseAuthentication();
app.UseAuthorization();
app.MapDuenioEndpoints();
app.MapMascotaEndpoints();
app.MapVeterinarioEndpoints();
app.MapUsuarioEndpoints();
app.MapEstudioEndpoints();
app.MapTipoVacunaEndpoints();
app.MapTurnoEndpoints();
app.MapConsultaEndpoints();
app.MapMedicamentoEndpoints();
app.MapMedicamentoConsultaEndpoints();
app.MapAuthEndpoints();

app.Run();
