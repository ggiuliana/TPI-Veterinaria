using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Data;
using ServiciosApp;
using WinFormsApp1;
using Microsoft.Extensions.Configuration;

namespace VeterinariaWinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Entity Framework
                    services.AddDbContext<VeterinariaContext>(options =>
                        options.UseSqlServer(
                            context.Configuration.GetConnectionString("VeterinariaDB")
                        ));

                    // Repositorios
                    services.AddDbContext<VeterinariaContext>();

                    services.AddScoped<IDuenioRepository, DuenioRepository>();
                    services.AddScoped<IMascotaRepository, MascotaRepository>();
                    services.AddScoped<IVeterinarioRepository, VeterinarioRepository>();
                    services.AddScoped<IUsuarioRepository, UsuarioRepository>();
                    services.AddScoped<IRolRepository, RolRepository>();
                    services.AddScoped<IEstudioRepository, EstudioRepository>();
                    services.AddScoped<ITipoVacunaRepository, TipoVacunaRepository>();
                    services.AddScoped<IMedicamentoRepository, MedicamentoRepository>();

                    services.AddScoped<IDuenioService, DuenioService>();
                    services.AddScoped<IMascotaService, MascotaService>();
                    services.AddScoped<IVeterinarioService, VeterinarioService>();
                    services.AddScoped<IUsuarioService, UsuarioService>();
                    services.AddScoped<IEstudioService, EstudioService>();
                    services.AddScoped<ITipoVacunaService, TipoVacunaService>();
                    services.AddScoped<IMedicamentoService, MedicamentoService>();

                    // Forms
                    services.AddTransient<Form1>();
                })
                .Build();

            using (host)
            {
                var login = host.Services.GetRequiredService<Form1>();

                Application.Run(login);
            }
        }
    }
}