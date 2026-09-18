using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModeloDominio;

namespace Data
{
    public class VeterinariaContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; } = null!;
        public DbSet<Duenio> Duenios { get; set; } = null!;
        public DbSet<Veterinario> Veterinarios { get; set; } = null!;
        public DbSet<Mascota> Mascotas { get; set; } = null!;
        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Rol> Roles { get; set; } = null!;
        public DbSet<Estudio> Estudios { get; set; } = null!;
        public DbSet<TipoVacuna> TipoVacunas { get; set; } = null!;
        public DbSet<Medicamento> Medicamentos { get; set; } = null!;
        public DbSet<Turno> Turnos { get; set; } = null!;
        public DbSet<Consulta> Consultas { get; set; } = null!;
        public DbSet<MedicamentosUsados> MedicamentosUsados { get; set; } = null!;
        public DbSet<Vacuna> Vacunas { get; set; } = null!;
        public VeterinariaContext(DbContextOptions<VeterinariaContext> options) : base(options)
        {
            //this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }
        internal VeterinariaContext()
        {
            //this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("VeterinariaDB")!;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasDiscriminator<string>("TipoPersona")
                .HasValue<Duenio>("Duenio")
                .HasValue<Veterinario>("Veterinario");

                entity.HasKey(p => p.IdPersona);
                entity.Property(p => p.IdPersona)
                .ValueGeneratedOnAdd();

                entity.Property(p => p.NombrePersona)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(p => p.Apellido)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(p => p.Dni)
                .IsRequired()
                .HasMaxLength(10);

                entity.Property(p => p.Telefono)
                .HasMaxLength(20);

                entity.Property(p => p.Mail)
                .IsRequired()
                .HasMaxLength(50);

                entity
                .HasIndex(p => p.Mail)
                .IsUnique();

                entity.HasOne(p => p.Usuario)
               .WithOne(u => u.Persona);
            });
            modelBuilder.Entity<Veterinario>(entity =>
            {
                entity.Property(v => v.Especialidad)
                .HasMaxLength(50);

                entity.Property(v => v.Matricula)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasIndex(v => v.Matricula)
                .IsUnique();

                entity.HasData(
                    new
                    { 
                        IdPersona = 1, 
                        NombrePersona = "Gerardo", 
                        Apellido = "Díaz", 
                        Telefono = "341252554", 
                        Mail = "gdiaz@veterinaria.com", 
                        Dni = "5125124", 
                        Direccion = "Génova 1344", 
                        Matricula = "AF1124", 
                        Especialidad = "Cardiología" 
                    },
                    new
                    {
                        IdPersona = 2,
                        NombrePersona = "Mariana",
                        Apellido = "Locre",
                        Telefono = "341251142",
                        Mail = "mlocre@veterinaria.com",
                        Dni = "55123142",
                        Direccion = "Corrientes 4880",
                        Matricula = "51W124",
                        Especialidad = "Oncología"
                    }
                    );

            });
            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(r => r.IdRol);

                entity.Property(r => r.IdRol)
                .ValueGeneratedOnAdd()
                .IsRequired();

                entity.Property(r => r.NombreRol)
                .IsRequired()
                .HasMaxLength(15);

                entity.HasData(
                    new
                    {
                        IdRol = 1,
                        NombreRol = "Administrador"
                    },
                    new
                    {
                        IdRol = 2,
                        NombreRol = "Veterinario"
                    },
                    new
                    {
                        IdRol = 3,
                        NombreRol = "Duenio"
                    }
                    );
            });
            modelBuilder.Entity<Mascota>(entity =>
            {
                entity.HasKey(m => m.IdMascota);

                entity.Property(m => m.IdMascota)
                .ValueGeneratedOnAdd();

                entity.Property(m => m.NombreMascota)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(m => m.Especie)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(m => m.Raza)
                .HasMaxLength(50);

                entity.Property(m => m.Castrado)
                .IsRequired();

                entity.Property(m => m.Sexo)
                .IsRequired();

                entity.Property(m => m.FechaNac)
                .IsRequired();

                entity.HasOne(m => m.Duenio)
                .WithMany();

                entity.HasMany(m => m.Vacunas)
                .WithOne(v => v.Mascota)
                .HasForeignKey(v => v.IdMascota)
                .IsRequired(false);
            });
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(u => u.IdUsuario);

                entity.Property(u => u.IdUsuario)
                .ValueGeneratedOnAdd();

                entity.Property(u => u.NombreUsuario)
                .IsRequired()
                .HasMaxLength(50);

                entity.HasIndex(u => u.NombreUsuario)
                .IsUnique();

                entity.Property(u => u.Contrasenia)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(u => u.EstadoUsuario)
                .IsRequired();

                entity.Property(u => u.FechaAlta)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(u => u.Persona)
                .WithOne(p => p.Usuario)
                .HasForeignKey<Usuario>(u => u.IdPersona)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(u => u.Rol)
                .WithMany()
                .HasForeignKey(u => u.IdRol)
                .IsRequired();

                entity.HasData(
                    new
                    {
                        IdUsuario = 1,
                        NombreUsuario = "admin",
                        Contrasenia = "admin123",
                        EstadoUsuario = "Activo",
                        IdRol = 1
                    },
                    new
                    {
                        IdUsuario = 2,
                        NombreUsuario = "vet",
                        Contrasenia = "vet123",
                        EstadoUsuario = "Activo",
                        IdPersona = 1,
                        IdRol = 2
                    }
                );
            });
            modelBuilder.Entity<Estudio>(entity =>
            {
                entity.HasKey(e => e.IdEstudio);

                entity.Property(e => e.IdEstudio)
                .ValueGeneratedOnAdd()
                .IsRequired();

                entity.Property(e => e.NombreEstudio)
                .IsRequired()
                .HasMaxLength(60);

                entity.Property(e => e.DescripcionEstudio)
                .IsRequired()
                .HasMaxLength(200);

                entity.HasData(
                    new
                    {
                        IdEstudio = 1,
                        NombreEstudio = "Resonancia Magnética",
                        DescripcionEstudio = "Se introduce el animal en un cilindro para visualizar su interior."
                    });
            });
            modelBuilder.Entity<TipoVacuna>(entity =>
            {
                entity.HasKey(t => t.IdTipoVacuna);

                entity.Property(t => t.IdTipoVacuna)
                .ValueGeneratedOnAdd()
                .IsRequired();

                entity.Property(t => t.NombreTipoVacuna)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(t => t.DescripcionTipoVacuna)
                .IsRequired()
                .HasMaxLength(100);

                entity.HasData(
                        new
                        {
                            IdTipoVacuna = 1,
                            NombreTipoVacuna = "Antitetanica",
                            DescripcionTipoVacuna = "Vacuna contra la bacteria del tetanos."
                        },
                        new
                        {
                            IdTipoVacuna = 2,
                            NombreTipoVacuna = "Antiviral",
                            DescripcionTipoVacuna = "Vacuna contra multiples viruses."
                        }
                    );

            });
            modelBuilder.Entity<Medicamento>(entity =>
            {
                entity.HasKey(m => m.IdMedicamento);

                entity.Property(m => m.IdMedicamento)
                .ValueGeneratedOnAdd()
                .IsRequired();

                entity.Property(m => m.NombreMedicamento)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(m => m.CantidadRestante)
                .IsRequired();

                entity.HasData(
                    new
                    {
                        IdMedicamento = 1,
                        NombreMedicamento = "Albendazol",
                        CantidadRestante = 4
                    });
            });
            modelBuilder.Entity<Turno>(entity =>
            {
                entity.HasKey(t => t.IdTurno);

                entity.Property(t => t.IdTurno)
                .ValueGeneratedOnAdd()
                .IsRequired();

                entity.Property(t => t.FechaTurno)
                .IsRequired();

                entity.Property(t => t.HoraTurno)
                .IsRequired();

                entity.Property(t => t.EstadoTurno)
                .IsRequired()
                .HasMaxLength(30);

                entity.HasOne(t => t.Mascota)
                .WithMany()
                .HasForeignKey(t => t.IdMascota)
                .IsRequired(false);

                entity.HasOne(t => t.Veterinario)
                .WithMany()
                .HasForeignKey(t => t.IdVeterinario)
                .IsRequired();
            });
            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(c => c.IdConsulta);

                entity.Property(c => c.IdConsulta)
                .ValueGeneratedOnAdd()
                .IsRequired();

                entity.Property(c => c.Diagnostico)
                .IsRequired()
                .HasMaxLength(200);

                entity.Property(c => c.Tratamiento)
                .IsRequired()
                .HasMaxLength(200);

                entity.Property(c => c.Peso)
                .IsRequired();

                entity.Property(c => c.Observaciones)
                .HasMaxLength(200);

                entity.HasMany(c => c.Estudios)
                .WithMany()
                .UsingEntity("ConsultaEstudio");

                entity.HasMany(c => c.MedicamentosUsados)
                .WithOne()
                .HasForeignKey("IdConsulta")
                .IsRequired(false);

                entity.HasOne(c => c.Turno)
                .WithMany()
                .HasForeignKey(c => c.IdTurno)
                .IsRequired();
            });
            modelBuilder.Entity<MedicamentosUsados>(entity =>
            {
                entity.HasKey(mu => new { mu.IdConsulta, mu.IdMedicamento });

                entity.Property(mu => mu.CantidadUsada)
                .IsRequired();
            });
            modelBuilder.Entity<Vacuna>(entity =>
            {
                entity.HasKey(v => new { v.IdTipoVacuna, v.IdMascota, v.FechaColocacion});

                entity.Property(v => v.FechaColocacion)
                .IsRequired();

                entity.HasOne(v => v.TipoVacuna)
                .WithMany()
                .HasForeignKey(v => v.IdTipoVacuna)
                .IsRequired();

                entity.HasOne(v => v.Mascota)
                .WithMany()
                .HasForeignKey(v => v.IdMascota)
                .IsRequired();
            });
        }
    }
}